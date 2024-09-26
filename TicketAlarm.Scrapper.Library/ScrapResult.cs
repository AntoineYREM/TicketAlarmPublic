using Org.OpenAPITools.Model;

namespace TicketAlarm.Scrapper.Library
{
    public partial class Scrapper
    {
        public class ScrapResult
        {
            public ShowDto ShowDto { get; set; }
            public ArtistDto ArtistDto { get; set; }
            public string? Screenshot { get; internal set; }
        }

    }
}
