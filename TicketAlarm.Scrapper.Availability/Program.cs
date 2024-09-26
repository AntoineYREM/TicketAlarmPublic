using TicketAlarm.Scrapper.Library;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var urlApi = (environmentName != null) ? "http://api:80/" : "https://localhost:7015/";
var urlSelenium = (environmentName != null) ? "http://selenium:4444/wd/hub" : null;

IScrapper scrapper = new Scrapper();

while (true)
{
    await scrapper.GetAvailabilitys();
    Thread.Sleep(5 * 60 * 1000);
}