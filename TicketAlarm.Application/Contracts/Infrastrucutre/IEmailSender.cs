using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Models;

namespace TicketAlarm.Application.Contracts.Infrastrucutre
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
