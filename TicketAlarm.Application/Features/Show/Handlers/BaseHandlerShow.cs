using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.Features.Show.Handlers
{
    public class BaseHandlerShow
    {
        public readonly IUnitOfWork UnitOfWork;
        public readonly IMapper Mapper;

 

        public BaseHandlerShow(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this.Mapper = mapper;
        }
    }
}
