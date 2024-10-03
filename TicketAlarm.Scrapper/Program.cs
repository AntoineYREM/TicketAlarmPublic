using TicketAlarm.Scrapper.Library;

IScrapper scrapper = new Scrapper();

while (true)
{
    var urlEvent = Console.ReadLine() ?? "";
    await scrapper.AddShow(urlEvent);
}