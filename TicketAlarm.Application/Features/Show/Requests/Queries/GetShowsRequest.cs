using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Show;

namespace TicketAlarm.Application.Features.Show.Requests.Queries
{
    public class GetShowsRequest : IRequest<List<ShowDto>>
    {
        public bool Active { get; set; } = true;
        public bool Trending { get; set; } = false;
    }
}
