using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.DTOs.Availability
{
    public class AvailabilityDto : Domain.Availability
    {
        public int IdShow { get; set; }
        public DateTime DateTimeAvailability { get; set; }
    }
}
