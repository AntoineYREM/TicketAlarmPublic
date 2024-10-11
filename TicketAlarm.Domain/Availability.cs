using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class Availability : BaseDomainEntity
    {
        public int IdShow { get; set; }
        public DateTime DateTimeAvailability { get; set; }
        public string? Screenshot { get; set; }
    }
}
