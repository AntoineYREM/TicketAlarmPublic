using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Show.Requests.Commands;
using TicketAlarm.Application.Features.Show.Requests.Queries;

namespace TicketAlarm.Application.Features.Show.Handlers.Commands
{
    public class UpdateShowRequestHandler : BaseHandlerShow, IRequestHandler<UpdateShowRequest, ShowDto>
    {
        public UpdateShowRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ShowDto> Handle(UpdateShowRequest request, CancellationToken cancellationToken)
        {
            var show = await UnitOfWork.ShowRepository.GetSingleAsync(a => a.Id == request.Id);
            show = UnitOfWork.ShowRepository.Update(show);
            return Mapper.Map<ShowDto>(show);
        }
    }
}
