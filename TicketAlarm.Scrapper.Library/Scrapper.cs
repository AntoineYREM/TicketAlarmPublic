using OpenQA.Selenium;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace TicketAlarm.Scrapper.Library
{
    public partial class Scrapper : IScrapper
    {
        private readonly WebDriver driver;
        private readonly ShowApi showApi;
        private readonly ArtistApi artistApi;
        private readonly AvailabilityApi availabilityApi;

        public Scrapper()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var urlApi = (environmentName != null) ? "http://api:80/" : "https://vps.aaaab3nzac1yc.website:81/";
            var urlSelenium = (environmentName != null) ? "http://selenium:4444/wd/hub" : null;

            driver = WebDriverFactory.GetDriver(urlSelenium);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            Configuration c = new Configuration();
            c.BasePath = urlApi;
            artistApi = new ArtistApi(c);
            showApi = new ShowApi(c);
            availabilityApi = new AvailabilityApi(c);
        }

        private ScrapResult ScrapEvent(string urlEvent, bool fullScrap = true)
        {
            driver.Url = urlEvent;

            var showInformationList = driver.FindElements(By.ClassName("breadcrumb-item"));

            var idShow = Convert.ToInt32(urlEvent.Split("-").Last().Substring(0, 8));
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
            var screenshot = driver.GetScreenshot();

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
                IdFnac = idShow,
                Title = showTitle,
                Url = urlEvent,
                Available = disponible
            };

            return new ScrapResult()
            {
                ArtistDto = artistDto,
                ShowDto = showDto,
                Screenshot = screenshot.AsBase64EncodedString
            };
        }


        public async Task AddShow(string urlShow)
        {
            var scrapResult = ScrapEvent(urlShow, true);
            var idArtist = await artistApi.ApiArtistsPostAsync(scrapResult.ArtistDto);
            scrapResult.ShowDto.IdArtist = idArtist;
            await showApi.ApiShowsPostAsync(scrapResult.ShowDto);
        }

        public async Task GetAvailabilitys()
        {
            var shows = await showApi.ApiShowsGetAsync(true);
            foreach (var show in shows)
            {
                try
                {
                    Console.WriteLine($"Le show {show.Id}-{show.Title} va être scrappé.");
                    var scrapResult = ScrapEvent(show.Url, false);

                    if (scrapResult.ShowDto.Available != show.Available)
                    {
                        if (scrapResult.ShowDto.Available)
                        {
                            var result = await availabilityApi.ApiAvailabilitysPostAsync(new AvailabilityDto()
                            {
                                IdShow = show.Id,
                                Screenshot = scrapResult.Screenshot
                            });
                        }

                        await showApi.ApiShowsIdShowPutAsync(show.Id, scrapResult.ShowDto);
                    }                     
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Le show {show.Id} n'a pas pu être scrappé");
                }
            }
        }
    }
}
