using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Show;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Show.Requests.Queries;

namespace TicketAlarm.Application.Features.Show.Handlers.Queries
{
    public class GetShowRequestHandler : BaseHandler ,IRequestHandler<GetShowRequest, ShowDto>
    {
        public GetShowRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ShowDto> Handle(GetShowRequest request, CancellationToken cancellationToken)
        {
            var show = await UnitOfWork.ShowRepository.GetSingleAsync(s => s.Id == request.Id, s  => s.Include(sb => sb.Artist));
            return Mapper.Map<ShowDto>(show);
        }
    }
}
