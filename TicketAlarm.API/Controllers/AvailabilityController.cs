using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.DTOs.Availability;
using TicketAlarm.Application.Features.Artist.Requests.Commands;
using TicketAlarm.Application.Features.Availability.Requests.Commands;
using TicketAlarm.Application.Features.Request.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class AvailabilityController : ControllerBase
    {
        private readonly IMediator mediator;

        public AvailabilityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost(ApiRoutes.CreateAvailability)]
        public async Task<ActionResult<List<int>>> CreateAvailability(AvailabilityDto availabilityDto)
        {
            var availabilityRequest = new CreateAvailabilityRequest()
            {
                AvailabilityDto = availabilityDto
            };
            var idAvailability = await mediator.Send(availabilityRequest);
            return Ok(idAvailability);
        }
    }
}
