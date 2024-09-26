using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Show;

namespace TicketAlarm.Application.Features.Show.Requests.Queries
{
    public class GetShowRequest : IRequest<ShowDto>
    {
        public int Id { get; set; }
    }
}
