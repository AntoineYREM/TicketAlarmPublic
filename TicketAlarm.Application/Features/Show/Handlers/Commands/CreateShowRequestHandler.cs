using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.DTOs.Show.Validators;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Show.Requests.Commands;

namespace TicketAlarm.Application.Features.Show.Handlers.Commands
{
    public class CreateShowRequestHandler : BaseHandler, IRequestHandler<CreateShowRequest, int>
    {
        public CreateShowRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Handle(CreateShowRequest request, CancellationToken cancellationToken)
        {
            var validator = new ShowDtoValidator(UnitOfWork.ArtistRepository);
            var validatorResult = await validator.ValidateAsync(request.ShowDto);

            if (validatorResult.IsValid == false)
                throw new ValidationException("Not valid");

            var show = Mapper.Map<Domain.Show>(request.ShowDto);
            show = await UnitOfWork.ShowRepository.AddAsync(show);
            await UnitOfWork.Save();
            return show.Id;
        }
    }
}
