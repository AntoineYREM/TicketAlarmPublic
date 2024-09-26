using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Domain;

namespace TicketAlarm.Persistence.Repositories
{
    public class AlarmRepository : GenericRepository<Alarm>, IAlarmRepository
    {
        public AlarmRepository(TicketAlarmDbContext context) : base(context)
        {
        }
    }
}
