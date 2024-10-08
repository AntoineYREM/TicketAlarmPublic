﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetShowsRequestHandler : BaseHandler ,IRequestHandler<GetShowsRequest, List<ShowDto>>
    {
        public GetShowsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<ShowDto>> Handle(GetShowsRequest request, CancellationToken cancellationToken)
        {
            var show = await UnitOfWork.ShowRepository.GetAllAsync(s => s.Include(s => s.Artist));
            if(request.Active) show = show.Where(s => s.DateTimeShow > DateTime.Now);
            return Mapper.Map<List<ShowDto>>(show);
        }
    }
}
