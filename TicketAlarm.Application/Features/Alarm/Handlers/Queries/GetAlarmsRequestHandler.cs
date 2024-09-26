using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.Features.Alarm.Requests.Queries;
using TicketAlarm.Application.Features.Commun;

namespace TicketAlarm.Application.Features.Alarm.Handlers.Queries
{
    public class GetAlarmsRequestHandler : BaseHandler,  IRequestHandler<GetAlarmsRequest, List<AlarmDto>>
    {
        public GetAlarmsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<AlarmDto>> Handle(GetAlarmsRequest request, CancellationToken cancellationToken)
        {
            var alarms = await UnitOfWork.AlarmRepository.GetAllAsync(a => a.IdShow == request.IdShow);
            return Mapper.Map<List<AlarmDto>>(alarms);
        }
    }
}
