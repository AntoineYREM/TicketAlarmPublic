﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAlarm.Application.DTOs.Artist;
using TicketAlarm.Application.Features.Artist.Requests.Commands;
using TicketAlarm.Application.Features.Request.Queries;

namespace TicketAlarm.API.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IMediator mediator;

        public ArtistController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(ApiRoutes.GetArtists)]
        public async Task<ActionResult<List<ArtistDto>>> GetListArtist()
        {
            var artistsRequest = new GetArtistListRequest();
            var artists = await mediator.Send(artistsRequest);
            return Ok(artists);
        }

        [HttpPost(ApiRoutes.CreateArtist)]
        public async Task<ActionResult<int>> CreateArtist(ArtistDto artistDto)
        {
            var createArtistsRequest = new CreateArtistRequest()
            {
                ArtistDto = artistDto
            };
            var idArtist = await mediator.Send(createArtistsRequest);
            return Ok(idArtist);
        }
    }
}