using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.Features.Commun
{
    public class BaseHandler
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMapper Mapper;

        public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
