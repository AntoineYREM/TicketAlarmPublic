using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Application.DTOs.Show.Validators
{
    public class ShowDtoValidator : AbstractValidator<BaseShowDto>
    {
        public ShowDtoValidator(IArtistRepository artistRepository)
        {
            RuleFor(s => s.IdArtist)
                .MustAsync(async (id, token) =>
                {
                    var artistExist = await artistRepository.GetSingleAsync(a => a.Id == id);
                    return artistRepository != null;
                }).WithMessage("{PropertyName} does not exist.");


            RuleFor(s => s.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} can't be empty")
                .NotNull()
                .MaximumLength(100);

            RuleFor(s => s.City)
                .NotEmpty()
                .WithMessage("{PropertyName} can't be empty")
                .NotNull()
                .MaximumLength(100);

            RuleFor(s => s.DateTimeShow)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.IdFnac)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.Arena)
                .NotEmpty()
                .NotNull();

            RuleFor(s => s.Url)
                .NotEmpty()
                .NotNull();
        }
    }
}
