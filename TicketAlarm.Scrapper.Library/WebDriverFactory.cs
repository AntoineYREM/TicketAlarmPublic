using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAlarm.Scrapper.Library
{
    public static class WebDriverFactory
    {
        public static WebDriver GetDriver(string? urlDriver)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--whitelisted-ips=''");

            if (urlDriver == null)
                return  new ChromeDriver(chromeOptions);

            return new RemoteWebDriver(new Uri(urlDriver), chromeOptions.ToCapabilities(), new TimeSpan(0, 0, 30));
        }
    }
}
