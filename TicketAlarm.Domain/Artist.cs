using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class Artist : BaseDomainEntity
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}