using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Common;

namespace TicketAlarm.Application.DTOs.Alarm
{
    public class AlarmDto : BaseDto
    {
        public int IdAlarm { get; set; }
        public int IdShow { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateTimeMailRequest { get; set; }
        public DateTime? DateTimeMailSent { get; set; }
        public DateTime? DateTimeTextRequest { get; set; }
        public DateTime? DateTimeTextSent { get; set; }
    }
}
