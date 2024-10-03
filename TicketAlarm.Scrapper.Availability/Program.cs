using TicketAlarm.Scrapper.Library;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var urlApi = (environmentName != null) ? "http://api:80/" : "https://localhost:7015/";
var urlSelenium = (environmentName != null) ? "http://selenium:4444/wd/hub" : null;

IScrapper scrapper = new Scrapper();

while (true)
{
    await scrapper.GetAvailabilitys();
    Thread.Sleep(120 * 1000);
}

//IHost _host = Host.CreateDefaultBuilder()
//    .ConfigureAppConfiguration((host, config) =>
//    {
//        //var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//        //config.AddJsonFile("Configuration/appsettings.json");
//        //if(env != null) config.AddJsonFile($"Configuration/appsettings.{env}.json");
//    })
//     .ConfigureServices(services =>
//     {
//         services.AddScoped<IScrapper, Scrapper>();
//     })
//     .Build();