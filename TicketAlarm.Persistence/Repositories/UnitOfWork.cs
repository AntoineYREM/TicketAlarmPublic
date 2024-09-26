using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;

namespace TicketAlarm.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAlarmRepository _alarmRepository;
        private IArtistRepository _artistRepository;
        private IAvailabilityRepository _availabilityRepository;    
        private IShowRepository _showRepository;
        private IUserRepository _userRepository;

        private  TicketAlarmDbContext _context { get; }
        public UnitOfWork(TicketAlarmDbContext context)
        {
            _context = context;
        }

        public IAlarmRepository AlarmRepository => _alarmRepository ??= new AlarmRepository(_context);

        public IArtistRepository ArtistRepository => _artistRepository ??= new ArtistRepository(_context);

        public IAvailabilityRepository AvailabilityRepository => _availabilityRepository ??= new AvailabilityRepository(_context);

        public IShowRepository ShowRepository => _showRepository ??= new ShowRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
