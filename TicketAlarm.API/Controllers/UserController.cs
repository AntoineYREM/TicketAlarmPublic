using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.User;
using TicketAlarm.Application.Features.User.Requests.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Authenticate)]
        public async Task<ActionResult<string>> Authenticate(LoginUserDto loginUserDto)
        {
            var getTokenRequest = new GetTokenRequest()
            {
                LoginUserDto = loginUserDto
            };

            var token = await mediator.Send(getTokenRequest);
            return Ok(token);
        }


    }
}
