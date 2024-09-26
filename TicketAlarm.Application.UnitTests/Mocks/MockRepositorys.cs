using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.DTOs.Alarm;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.UnitTests.Mocks
{
    public static class MockRepositorys
    {
        public static Mock<IArtistRepository> GetArtistRepository()
        {
            var shows = new List<Artist>()
            {
                new Artist()
                {
                    Id = 1,
                    Name = "Billie Eilish",
                    UrlPhoto = "https://www.fnacspectacles.com/obj/mam/france/9c/4a/billi-eilish-tickets_152737_1374605_222x222.jpg"
                }
            };

            var mockRepository = new Mock<IArtistRepository>();



            return mockRepository;
        }


        public static Mock<IShowRepository> GetShowRepository()
        {
            var shows = new List<Show>()
            {
                new Show()
                {
                    Id = 1,
                    IdArtist = 1,
                    Arena = "Accor Arena",
                    Available = false,
                    City = "Paris",
                    DateTimeShow = new DateTime(638851788000000000),
                    IdFnac = 18631108,
                    Title = "Billie Eilish - Hit Me Hard and Soft Tour",
                    Url = "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/"
                }
            };

            var mockRepository = new Mock<IShowRepository>();


            mockRepository.Setup(r => r.AddAsync(It.IsAny<Show>())).ReturnsAsync((Show show) =>
            {
                shows.Add(show);
                return shows.Last();
            });

            return mockRepository;
        }

        public static Mock<IAlarmRepository> GetAlarmRepository()
        {
            var alarms = new List<Alarm>()
            {
                new Alarm(){
                    Id = 1,
                    IdShow = 1,
                    Mail = "test@gmail.com",
                    Phone = "+33622334455",
                }
            };

            var mockRepository = new Mock<IAlarmRepository>();

            mockRepository.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<Alarm, bool>>>())).ReturnsAsync((Expression<Func<Alarm, bool>> expression) =>
            {
                return alarms.AsQueryable().Where(expression).AsQueryable();
            });

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(() =>
            {
                return alarms.AsQueryable();
            });

            mockRepository.Setup(r => r.AddAsync(It.IsAny<Alarm>())).ReturnsAsync((Alarm alarm) =>
            {
                alarms.Add(alarm);
                return alarms.Last();
            });


            mockRepository.Setup(r => r.Update(It.IsAny<Alarm>())).Returns((Alarm alarm) =>
            {
                var alarmFound = alarms.First(a => a.Id == alarm.Id);
                alarms.Remove(alarmFound);
                alarms.Add(alarm);
                return alarm;
            });

            return mockRepository;
        }
    }
}
