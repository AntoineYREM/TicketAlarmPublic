using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using TicketAlarm.Application.Contracts.Infrastrucutre;
using TicketAlarm.Application.Models;
using TicketAlarm.Application.Template.Email;
using TicketAlarm.Domain;
using HtmlAgilityPack;

namespace TicketAlarm.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings EmailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            EmailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var html = new HtmlDocument();
            var bodyHtml = email.Body;
            var client = new SendGridClient(EmailSettings.ApiKey);
            var from = new EmailAddress(EmailSettings.FromAddress, EmailSettings.FromName);
            var subject = email.Subject;
            var to = new EmailAddress(email.To, email.To);
            var plainTextContent = html.DocumentNode.InnerText;
            var htmlContent = bodyHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}