using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.DTOs.User;

namespace TicketAlarm.Application.Features.User.Requests.Queries
{
    public class GetTokenRequest : IRequest<string>
    {
        public LoginUserDto LoginUserDto { get; set; }
    }
}
