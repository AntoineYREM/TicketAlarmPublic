using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.Models;

namespace TicketAlarm.Application.Features.Message.Requests.Commands
{
    public class SendEmailRequest : IRequest<bool>
    {
        public AlarmDto AlarmInformation { get; set; }
    }
}
