using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Availability.Validators;
using TicketAlarm.Application.Features.Alarm.Requests.Commands;
using TicketAlarm.Application.Features.Availability.Requests.Commands;
using TicketAlarm.Application.Models;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Availability.Handlers.Commands
{
    public class CreateAvailabilityRequestHandler : BaseHandlerAvailability, IRequestHandler<CreateAvailabilityRequest, int>
    {
        public CreateAvailabilityRequestHandler(IUnitOfWork unitOfWork, IEmailSender emailSender,  IMapper mapper) : base(unitOfWork, emailSender, mapper)
        {
        }

        public async Task<int> Handle(CreateAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var availabilityValidator = new AvailabilityDtoValidator(UnitOfWork.ShowRepository);
            var validatorResult = await availabilityValidator.ValidateAsync(request.AvailabilityDto);

            if (validatorResult.IsValid == false)
                throw new Exception();

            var availability = Mapper.Map<Domain.Availability>(request.AvailabilityDto);
            var availabilityId = UnitOfWork.AvailabilityRepository.AddAsync(availability).Result.Id;


            var email = new Email()
            {
                To = "antoine.mano@gmail.com",
                Body = "Nouvelle disponibilité",
                Subject = "Nouvelle disponibilité"
            };

            try
            {
                await EmailSender.SendEmail(email);
            }
            catch (Exception e)
            {

            }

            await UnitOfWork.Save();

            return availabilityId;
        }
    }
}
