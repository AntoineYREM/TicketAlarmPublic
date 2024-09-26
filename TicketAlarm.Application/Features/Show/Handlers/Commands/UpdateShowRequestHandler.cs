using AutoMapper;
using MediatR;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Show.Requests.Commands;

namespace TicketAlarm.Application.Features.Show.Handlers.Commands
{
    public class UpdateShowRequestHandler : BaseHandler, IRequestHandler<UpdateShowRequest, ShowDto>
    {
        public UpdateShowRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ShowDto> Handle(UpdateShowRequest request, CancellationToken cancellationToken)
        {
            var show = await UnitOfWork.ShowRepository.GetSingleAsync(a => a.Id == request.Id);
            show.Available = request.ShowDto.Available;
            show.DateTimeShow = request.ShowDto.DateTimeShow;
            show = UnitOfWork.ShowRepository.Update(show);
            return Mapper.Map<ShowDto>(show);
        }
    }
}
