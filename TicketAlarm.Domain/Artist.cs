using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class Artist : BaseDomainEntify
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
    }
}