using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.DTOs.Availability.Validators
{
    public class AvailabilityDtoValidator : AbstractValidator<AvailabilityDto>
    {
        public AvailabilityDtoValidator(IShowRepository showRepository)
        {
            RuleFor(s => s.IdShow)
            .MustAsync(async (id, token) =>
            {
                var showExist = await showRepository.GetSingleAsync(a => a.Id == id);
                return showExist != null;
            }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
