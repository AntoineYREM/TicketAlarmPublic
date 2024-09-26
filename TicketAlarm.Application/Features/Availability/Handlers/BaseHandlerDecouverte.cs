using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.Features.Availability.Handlers
{
    public class BaseHandlerAvailability
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMapper Mapper;
        public readonly IEmailSender EmailSender;

        public BaseHandlerAvailability(IUnitOfWork unitOfWork, IEmailSender emailSender , IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            EmailSender = emailSender;
            Mapper = mapper;
        }


    }
}
