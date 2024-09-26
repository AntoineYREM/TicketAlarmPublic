using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.User.Requests.Queries;

namespace TicketAlarm.Application.Features.User.Handlers.Queries
{
    public class GetTokenRequestHandler : BaseHandlerExtended, IRequestHandler<GetTokenRequest, string>
    {
        public GetTokenRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender, IMessageBrokerSender messageBrokerSender, ITokenGenerator tokenGenerator) : base(unitOfWork, mapper, emailSender, messageBrokerSender, tokenGenerator)
        {
        }

        public async Task<string> Handle(GetTokenRequest request, CancellationToken cancellationToken)
        {
            var user = await UnitOfWork.UserRepository.GetSingleAsync(u => u.EmailAddress == request.LoginUserDto.EmailAddress && u.Password == request.LoginUserDto.Password);

            if (user == null) return "";
            
            var token = TokenGenerator.GenerateToken(user.Role, user.EmailAddress);

            return token;
        }
    }
}
