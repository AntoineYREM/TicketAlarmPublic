﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Artist.Requests.Commands;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Artist.Handlers.Commands
{
    public class CreateArtistRequestHandler : BaseHandlerArtist,  IRequestHandler<CreateArtistRequest, int>
    {
        public CreateArtistRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<int> Handle(CreateArtistRequest request, CancellationToken cancellationToken)
        {
            var artist = Mapper.Map<Domain.Artist>(request.ArtistDto);
            var createdArtist = await UnitOfWork.ArtistRepository.AddAsync(artist);
            await UnitOfWork.Save();
            return createdArtist.Id;
        }
    }
}