using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Artist;

namespace TicketAlarm.Application.Features.Request.Queries
{
    public class GetArtistRequest : IRequest<ArtistDto>
    {
        public int Id { get; set; }
    }
}
