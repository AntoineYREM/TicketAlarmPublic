namespace TicketAlarm.Scrapper.Library
{
    public interface IScrapper
    {
        Task AddShow(string urlShow);
        Task GetAvailabilitys();
    }
}