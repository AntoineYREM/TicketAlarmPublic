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
        public static WebDriver GetDriver(bool local = false)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--whitelisted-ips=''");

            WebDriver remoteWebDriver;
            if (local)
                remoteWebDriver = new ChromeDriver(chromeOptions);
            else
                remoteWebDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), chromeOptions.ToCapabilities(), new TimeSpan(0, 0, 30));

            return remoteWebDriver;
        }
    }
}
