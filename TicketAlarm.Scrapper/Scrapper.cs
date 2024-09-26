using OpenQA.Selenium;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using static System.Net.WebRequestMethods;

namespace TicketAlarm.Scrapper
{
    public class Scrapper
    {
        private readonly WebDriver driver;

        public Scrapper()
        {
            driver = WebDriverFactory.GetDriver(true);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
        }

        public async Task ScrapEventAsync(string urlEvent)
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

            driver.Url = artistLink;

            var imageLinkTop = $"{driver.FindElements(By.ClassName("stage-content-image")).FirstOrDefault()?.FindElement(By.TagName("img")).GetAttribute("src")}";
            var imageLinkBottom = $"{driver.FindElements(By.ClassName("artist-image")).FirstOrDefault()?.FindElement(By.TagName("img")).GetAttribute("data-src")}";
            var imageLink = imageLinkTop != "" ? imageLinkTop : $"https://www.fnacspectacles.com{imageLinkBottom}";


            Configuration c = new Configuration();
            c.BasePath = "https://localhost:7015/";
            ArtistApi artistApi = new ArtistApi(c);
            ShowApi showApi = new ShowApi(c);

            Console.WriteLine("a");

            var idArtist = await artistApi.ApiArtistsPostAsync(new Org.OpenAPITools.Model.ArtistDto()
            {
                Name = artistName,
                UrlPhoto = imageLink
            });



            Console.WriteLine("b");

            await showApi.ApiShowsPostAsync(new Org.OpenAPITools.Model.ShowDto() {
                Arena = arena,
                IdArtist = idArtist,
                City = city,
                DateTimeShow = dateTimeShow,
                IdFnac = 8,
                Title = showTitle,
                Url = urlEvent,
            });

            Console.WriteLine("c");
            Console.WriteLine(imageLink);
        }
    }
}
