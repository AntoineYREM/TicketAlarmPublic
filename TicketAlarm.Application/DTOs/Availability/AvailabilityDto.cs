using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Common;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.DTOs.Availability
{
    public class AvailabilityDto : BaseDto
    {
        public int IdShow { get; set; }
        public string? Screenshot { get; set; }
    }
}
