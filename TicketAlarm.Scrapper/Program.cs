using TicketAlarm.Scrapper.Library;

IScrapper scrapper = new Scrapper();

while (true)
{
    Console.WriteLine("URL Fnac du show : ");
    var urlEvent = Console.ReadLine() ?? "";
    await scrapper.AddShow(urlEvent);
}