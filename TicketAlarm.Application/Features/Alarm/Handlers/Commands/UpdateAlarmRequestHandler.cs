﻿using AutoMapper;
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

namespace TicketAlarm.Application.Features.Alarm.Handlers.Commands
{
    public class UpdateAlarmRequestHandler :  BaseHandlerAlarm, IRequestHandler<UpdateAlarmRequest, AlarmDto>
    {
        public UpdateAlarmRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<AlarmDto> Handle(UpdateAlarmRequest request, CancellationToken cancellationToken)
        {
            var alarm = await UnitOfWork.AlarmRepository.GetSingleAsync(a => a.Id == request.Id);
            alarm = UnitOfWork.AlarmRepository.Update(alarm);
            return Mapper.Map<AlarmDto>(alarm);
        }
    }
}