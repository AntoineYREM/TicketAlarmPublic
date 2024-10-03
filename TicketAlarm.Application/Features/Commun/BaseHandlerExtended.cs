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
    public class BaseHandlerExtended
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMapper Mapper;
        public readonly IEmailSender EmailSender;
        public readonly IMessageBrokerSender MessageBrokerSender;

        public BaseHandlerExtended(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender, IMessageBrokerSender messageBrokerSender)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            EmailSender = emailSender;
            MessageBrokerSender = messageBrokerSender;
        }
    }
}
