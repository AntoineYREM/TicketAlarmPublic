using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.Features.Alarm.Handlers
{
    public class BaseHandlerAlarm
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMapper Mapper;

        public BaseHandlerAlarm(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this.Mapper = mapper;
        }
    }
}
