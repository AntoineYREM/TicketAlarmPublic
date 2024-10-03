using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.Availability;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Availability.Requests.Commands
{
    public class CreateAvailabilityRequest : IRequest<int>
    {
        public AvailabilityDto AvailabilityDto { get; set; }
    }
}
