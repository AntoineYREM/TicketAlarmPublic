﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAlarm.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IAlarmRepository AlarmRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IAvailabilityRepository AvailabilityRepository { get; }
        IShowRepository ShowRepository { get; }

        Task Save();
    }
}