using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockArtistRepo = MockRepositorys.GetArtistRepository();
            var mockShowRepo = MockRepositorys.GetShowRepository();
            var mockAlarmRepo = MockRepositorys.GetAlarmRepository();
            var mockAvailabilityRepo = MockRepositorys.GetAvailabilityRepository();

            mockUow.Setup(r => r.ArtistRepository).Returns(mockArtistRepo.Object);
            mockUow.Setup(r => r.ShowRepository).Returns(mockShowRepo.Object);
            mockUow.Setup(r => r.AlarmRepository).Returns(mockAlarmRepo.Object);
            mockUow.Setup(r => r.AvailabilityRepository).Returns(mockAvailabilityRepo.Object);

            return mockUow;
        }
    }
}
