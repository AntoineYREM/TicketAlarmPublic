using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.Features.Commun
{
    public class BaseHandlerExtended : BaseHandler
    {
        public readonly IEmailSender EmailSender;
        public readonly IMessageBrokerSender MessageBrokerSender;
        public readonly ITokenGenerator TokenGenerator;

        public BaseHandlerExtended(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender, IMessageBrokerSender messageBrokerSender, ITokenGenerator tokenGenerator) : base(unitOfWork, mapper)
        {
            EmailSender = emailSender;
            MessageBrokerSender = messageBrokerSender;
            TokenGenerator = tokenGenerator;
        }
    }
}
