using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Message.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmailController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost(ApiRoutes.SendEmail)]
        public async Task<ActionResult<int>> SendEmail(AlarmDto alarmDto)
        {
            var createShowRequest = new SendEmailRequest()
            {
                AlarmInformation = alarmDto
            };

            var sended = await mediator.Send(createShowRequest);
            return Ok(sended);
        }
    }
}
