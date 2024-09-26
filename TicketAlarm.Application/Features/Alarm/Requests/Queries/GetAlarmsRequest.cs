using MediatR;
using TicketAlarm.Application.DTOs.Alarm;

namespace TicketAlarm.Application.Features.Alarm.Requests.Queries
{
    public class GetAlarmsRequest : IRequest<List<AlarmDto>>
    {
        public int IdShow { get; set; }
    }
}
