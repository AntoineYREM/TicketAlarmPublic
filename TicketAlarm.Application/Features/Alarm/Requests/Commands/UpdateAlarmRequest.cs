using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Alarm;

namespace TicketAlarm.Application.Features.Alarm.Requests.Commands
{
    public class UpdateAlarmRequest : IRequest<AlarmDto>
    {
        public int Id { get; set; }
        public AlarmDto AlarmDto { get; set; }
    }
}
