using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAlarm.Application.DTOs.User
{
    public class LoginUserDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
