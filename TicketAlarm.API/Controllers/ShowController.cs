using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShowController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.GetShows)]
        public async Task<ActionResult<List<ShowDto>>> GetListShow(bool active)
        {
            var getShowsRequest = new GetShowsRequest()
            {
                Active = active
            };
            var listShow = await mediator.Send(getShowsRequest);
            return Ok(listShow);
        }

        [HttpGet(ApiRoutes.GetShow)]
        public async Task<ActionResult<ShowDto>> GetShow(int idShow)
        {
            var getShowsRequest = new GetShowRequest()
            {
                Id = idShow
            };
            var show = await mediator.Send(getShowsRequest);
            return Ok(show);
        }

        [HttpPost(ApiRoutes.CreateShow)]
        public async Task<ActionResult<int>> CreateShow(ShowDto showDto)
        {
            var createShowRequest = new CreateShowRequest()
            {
                ShowDto = showDto
            };
            var idShow = await mediator.Send(createShowRequest);
            return Ok(idShow);
        }

        [HttpPut(ApiRoutes.UpdateShow)]
        public async Task<ActionResult<ShowDto>> UpdateShow(int idShow, ShowDto showDto)
        {
            var updateShowRequest = new UpdateShowRequest()
            {
                Id = idShow,
                ShowDto = showDto
            };
            showDto = await mediator.Send(updateShowRequest);
            return Ok(showDto);
        }
    }
}
