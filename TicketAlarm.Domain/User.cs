using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain.Common;

namespace TicketAlarm.Domain
{
    public class User : BaseDomainEntity
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
