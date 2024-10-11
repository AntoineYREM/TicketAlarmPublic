using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Contracts.Persistence;
using TicketAlarm.Application.Features.Commun;
using TicketAlarm.Application.Features.Message.Requests.Commands;
using TicketAlarm.Application.Models;
using TicketAlarm.Application.Template.Email;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Features.Message.Handlers.Commands
{
    public class SendEmailRequestHandler : BaseHandlerExtended, IRequestHandler<SendEmailRequest, bool>
    {
        public SendEmailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailSender emailSender, IMessageBrokerSender messageBrokerSender, ITokenGenerator tokenGenerator) : base(unitOfWork, mapper, emailSender, messageBrokerSender, tokenGenerator)
        {
        }

        public async Task<bool> Handle(SendEmailRequest request, CancellationToken cancellationToken)
        {
            var alarmInformation = request.AlarmInformation;

            var alarm =  await UnitOfWork.AlarmRepository.GetSingleAsync(a => a.Id == alarmInformation.IdAlarm);
            alarm.DateTimeMailSent = DateTime.UtcNow;
            UnitOfWork.AlarmRepository.Update(alarm);

            var show = await UnitOfWork.ShowRepository.GetSingleAsync(s => s.Id ==  alarmInformation.IdShow, s => s.Include(s => s.Artist));
            var email = new Email()
            {
                To = alarmInformation.Mail,
                Body = EmailTemplate.GetMailShowAvailableBody(show),
                Subject = EmailTemplate.GetMailShowAvailableTitle(show),
            };
            var result = await EmailSender.SendEmail(email);
            if (!result) throw new Exception("Une erreur est survenue lors de l'envoi du mail");


            await UnitOfWork.Save();
            return result;
        }
    }
}
