

using TicketAlarm.Scrapper.Library;

Scrapper scrapper = new Scrapper("https://localhost:7015/");

while (true)
{
    var urlEvent = Console.ReadLine() ?? "";
    await scrapper.AddShow(urlEvent);
}

