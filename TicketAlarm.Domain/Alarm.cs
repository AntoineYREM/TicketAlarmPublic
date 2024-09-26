using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class Alarm : BaseDomainEntity
    {
        public Show Show { get; set; }
        public int IdShow { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateTimeMailRequest { get; set; }
        public DateTime? DateTimeMailSent { get; set; }
        public DateTime? DateTimeTextRequest { get; set; }
        public DateTime? DateTimeTextSent { get; set; }
    }
}
