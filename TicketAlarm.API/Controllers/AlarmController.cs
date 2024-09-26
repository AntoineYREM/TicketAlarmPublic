using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Alarm.Requests.Commands;
using TicketAlarm.Application.Features.Alarm.Requests.Queries;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlarmController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.GetAlarms)]
        public async Task<ActionResult<List<ShowDto>>> GetListAlarms(int idShow)
        {
            var getAlarmsRequest = new GetAlarmsRequest()
            {
                IdShow = idShow
            };
            var listAlarms = await mediator.Send(getAlarmsRequest);
            return Ok(listAlarms);
        }

        [HttpPost(ApiRoutes.CreateAlarm)]
        public async Task<ActionResult<int>> CreateAlarm(AlarmDto alarmDto)
        {
            var createAlarmRequest = new Application.Features.Alarm.Requests.Commands.CreateShowRequest()
            {
                AlarmDto = alarmDto
            };
            var idAlarm = await mediator.Send(createAlarmRequest);
            return Ok(idAlarm);
        }

        [Authorize(Roles = "admin")]
        [HttpPut(ApiRoutes.UpdateAlarm)]
        public async Task<ActionResult<ShowDto>> UpdateAlarm(int idAlarm, AlarmDto alarmDto)
        {
            var updateAlarmRequest = new UpdateAlarmRequest()
            {
                Id = idAlarm,
                AlarmDto = alarmDto
            };
            alarmDto = await mediator.Send(updateAlarmRequest);
            return Ok(alarmDto);
        }
    }
}
