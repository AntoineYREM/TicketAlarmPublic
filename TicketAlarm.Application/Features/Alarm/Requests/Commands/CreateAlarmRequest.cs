using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.Responses;

namespace TicketAlarm.Application.Features.Alarm.Requests.Commands
{
    public class CreateShowRequest : IRequest<BaseCommandResponse<int>>
    {
        public AlarmDto AlarmDto { get; set; }
    }
}
