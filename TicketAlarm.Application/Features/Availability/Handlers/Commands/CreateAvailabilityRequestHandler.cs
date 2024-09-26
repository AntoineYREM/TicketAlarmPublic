using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Availability.Validators;
using TicketAlarm.Application.Features.Alarm.Requests.Commands;
using TicketAlarm.Application.Features.Availability.Requests.Commands;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Models;
using TicketAlarm.Application.Template.Email;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Availability.Handlers.Commands
{
    public class CreateAvailabilityRequestHandler : BaseHandlerExtended, IRequestHandler<CreateAvailabilityRequest, int>
    {
        public CreateAvailabilityRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender, IMessageBrokerSender messageBrokerSender, ITokenGenerator tokenGenerator) : base(unitOfWork, mapper, emailSender, messageBrokerSender, tokenGenerator)
        {
        }

        public async Task<int> Handle(CreateAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var availabilityValidator = new AvailabilityDtoValidator(UnitOfWork.ShowRepository);
            var validatorResult = await availabilityValidator.ValidateAsync(request.AvailabilityDto);

            if (validatorResult.IsValid == false)
                throw new Exception();

            
            var availability = Mapper.Map<Domain.Availability>(request.AvailabilityDto);
            availability.DateTimeAvailability = DateTime.UtcNow;
            availability = UnitOfWork.AvailabilityRepository.AddAsync(availability).Result;
 
            // TODO: Changer la condition de date
            var alarms =  await UnitOfWork.AlarmRepository.GetAllAsync(a => a.IdShow == request.AvailabilityDto.IdShow && a.DateTimeMailRequest == null);

            foreach(var alarm in alarms.ToList())
            {
                // Send request to RabbitMq
                var result = await MessageBrokerSender.QueueMessage(Mapper.Map<AlarmDto>(alarm));

                if (result)
                {
                    alarm.DateTimeMailRequest = DateTime.UtcNow;
                    UnitOfWork.AlarmRepository.Update(alarm);
                }
                else
                {
                    throw new Exception("RabbitMq n'est pas disponible.");
                }
            }

            await UnitOfWork.Save();
            return availability.Id;
        }
    }
}
