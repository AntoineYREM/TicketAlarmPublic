using Microsoft.Extensions.Configuration;
using System.Timers;
using TicketAlarm.Scrapper.Library;
using Microsoft.Extensions.Configuration.Json;
using Timer = System.Timers.Timer;


var configuration = new ConfigurationBuilder()
     .AddJsonFile($"Configuration/appsettings.json");

var config = configuration.Build();
var apiUrl = config.GetRequiredSection("apiUrl").Value;

if (apiUrl == null) throw new Exception("L'URL de l'API n'a pas pu être déterminée.");
Scrapper scrapper = new Scrapper(apiUrl);

while (true)
{
    Thread.Sleep(60 * 1000);
    await scrapper.GetAvailabilitys();
}