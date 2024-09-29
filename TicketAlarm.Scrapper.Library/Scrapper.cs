using OpenQA.Selenium;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using static System.Net.WebRequestMethods;

namespace TicketAlarm.Scrapper.Library
{
    public partial class Scrapper
    {
        private readonly WebDriver driver;
        private readonly ShowApi showApi;
        private readonly ArtistApi artistApi;
        private readonly AvailabilityApi availabilityApi;

        public Scrapper(string urlApi)
        {
            driver = WebDriverFactory.GetDriver(false);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            Configuration c = new Configuration();
            c.BasePath = urlApi;
            artistApi = new ArtistApi(c);
            showApi = new ShowApi(c);
            availabilityApi = new AvailabilityApi(c);
        }

        private async Task<ScrapResult> ScrapEventAsync(string urlEvent, bool fullScrap = true)
        {
            driver.Url = urlEvent;

            var showInformationList = driver.FindElements(By.ClassName("breadcrumb-item"));

            var idShow = urlEvent.Split("-").Last().Substring(0, 8);
            var localisation = driver.FindElement(By.XPath("//span[@data-qa='event-venue']"));
            var cityBrut = localisation
                                .FindElement(By.TagName("span"))
                                .Text;
            var arena = localisation
                                .FindElement(By.TagName("a"))
                                .GetAttribute("text");

            var city = cityBrut.Substring(0, cityBrut.Length - 2);
            var artistName = showInformationList[2].FindElement(By.TagName("a")).GetAttribute("text");
            var artistLink = showInformationList[2].FindElement(By.TagName("a")).GetAttribute("href");
            var showTitle = showInformationList[3].FindElement(By.TagName("a")).GetAttribute("text");
            var showDateBrut = showInformationList[4].FindElement(By.TagName("a")).GetAttribute("text");
            var day = Convert.ToInt32(showDateBrut.Split("/")[0]);
            var month = Convert.ToInt32(showDateBrut.Split("/")[1]);
            var year = Convert.ToInt32(showDateBrut.Split("/")[2].Split(" ")[0]);
            var hour = Convert.ToInt32(showDateBrut.Split("/")[2].Split(" ")[1].Split(":")[0]);
            var minute = Convert.ToInt32(showDateBrut.Split("/")[2].Split(" ")[1].Split(":")[1]);
            var dateTimeShow = new DateTime(year, month, day, hour, minute, 0);
            var disponible = !driver.FindElements(By.ClassName("evi-widget-subscription")).Any();


            var imageLink = "";
            if (fullScrap)
            {
                driver.Url = artistLink;
                var imageLinkTop = $"{driver.FindElements(By.ClassName("stage-content-image")).FirstOrDefault()?.FindElement(By.TagName("img")).GetAttribute("src")}";
                var imageLinkBottom = $"{driver.FindElements(By.ClassName("artist-image")).FirstOrDefault()?.FindElement(By.TagName("img")).GetAttribute("data-src")}";
                imageLink = imageLinkTop != "" ? imageLinkTop : $"https://www.fnacspectacles.com{imageLinkBottom}";
            }



            var artistDto = new Org.OpenAPITools.Model.ArtistDto()
            {
                Name = artistName,
                UrlPhoto = imageLink
            };

           

            var showDto = new Org.OpenAPITools.Model.ShowDto()
            {
                Arena = arena,
                IdArtist = 0,
                City = city,
                DateTimeShow = dateTimeShow,
                IdFnac = 8,
                Title = showTitle,
                Url = urlEvent,
                Available = disponible
            };

            return new ScrapResult()
            {
                ArtistDto = artistDto,
                ShowDto = showDto
            };
        }


        public async Task AddShow(string urlShow)
        {
            var scrapResult =  await ScrapEventAsync(urlShow, true);
            
            var idArtist = await artistApi.ApiArtistsPostAsync(scrapResult.ArtistDto);
            scrapResult.ShowDto.IdArtist = idArtist;
            var idShow = await showApi.ApiShowsPostAsync(scrapResult.ShowDto);

            Console.WriteLine(idShow);
        } 

        public async Task GetAvailabilitys()
        {
            var shows = await showApi.ApiShowsGetAsync(true);
            foreach(var show in shows)
            {
                var scrapResult = await ScrapEventAsync(show.Url, false);
                if (scrapResult.ShowDto.Available)
                {
                    var result = await availabilityApi.ApiAvailabilitysPostAsync(new AvailabilityDto()
                    {
                        DateTimeAvailability = DateTime.Now,
                        IdShow = show.Id
                    });
                }
            }

        }

    }
}
