using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class Show : BaseDomainEntity
    {
       
        public string Title { get; set; }
        public DateTime DateTimeShow { get; set; }
        public int IdFnac { get; set; }
        public string City { get; set; }
        public string Arena { get; set; }
        public string Url { get; set; }
        public bool Available { get; set; }

        public int IdArtist { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Alarm> Alarms { get; set; }
    }
}
