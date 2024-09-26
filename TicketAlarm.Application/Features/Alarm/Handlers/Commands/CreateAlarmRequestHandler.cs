using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.Features.Alarm.Requests.Commands;
using TicketAlarm.Application.Features.Alarm.Requests.Queries;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Responses;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Alarm.Handlers.Commands
{
    public class CreateAlarmRequestHandler : BaseHandler, IRequestHandler<CreateShowRequest, BaseCommandResponse<int>>
    {
        public CreateAlarmRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateShowRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var alarm = Mapper.Map<Domain.Alarm>(request.AlarmDto);
            var alarmId = await UnitOfWork.AlarmRepository.AddAsync(alarm);
            await UnitOfWork.Save();

            response.Return = alarmId.Id;
            return response;
        }
    }
}
