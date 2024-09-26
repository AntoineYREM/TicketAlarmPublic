using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.DTOs.User;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;
using TicketAlarm.Application.Features.User.Requests.Queries;

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

        [ResponseCache(Duration = 60)]
        [HttpGet(ApiRoutes.GetShows)]
        public async Task<ActionResult<List<ShowDto>>> GetListShow(bool active = true, bool trending = false)
        {
            var getShowsRequest = new GetShowsRequest()
            {
                Active = active,
                Trending = trending
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
        public async Task<ActionResult<int>> CreateShow(BaseShowDto showDto)
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
