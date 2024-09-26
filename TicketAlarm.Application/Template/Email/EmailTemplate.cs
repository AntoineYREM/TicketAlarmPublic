using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAlarm.Domain;

namespace TicketAlarm.Application.Template.Email
{
    public static class EmailTemplate
    {
        public static string GetMailShowAvailableBody(Show show)
        {
            var mail = $"<div style='max-width:600px;margin:0px auto'>" +
                $" <table>" +
                $"<tr><td align='center'><table><tr>" +
                $"<td style='font-family:Open Sans,arial;font-size:24px;font-weight:bold;line-height:27px;text-align:left;color:#124E66 '>" +
                $"Ticket Alarm ⏰" +
                $"</td>" +
                $"</tr></table></td></tr><tr><td>" +
                $"<div style='font-family:Open Sans,arial;font-size:20px;font-weight:100;line-height:27px;text-align:center;color:#124E66'>" +
                $"{GetMailShowAvailableTitle(show)}" +
                $"</div></td></tr><tr><td><center>" +
                $"<img alt='' src='{show.Artist.UrlPhoto }' style='border:0px;border-radius:10px 10px 0px 0px;display:block;outline:none;text-decoration:none;width:50%'>" +
                $"</center></td></tr><tr><td>" +
                $"<div style='font-family:Open Sans,arial;font-size:14px;line-height:27px;color:#1d1d1c' align='left'>" +
                $"<center><a style='font-family:Open Sans,arial;font-size:20px;line-height:27px;color:#124E66'" +
                $"href='{show.Url}'>Lien vers la billetterie<a> 🎫</center>" +
                $"</div>" +
                $"</td>" +
                $"</tr>" +
                $"</table></div>";
            return mail;
        }

        public static string GetMailShowAvailableTitle(Show show)
        {
            var title = $"Des billets pour \"{show.Title}\" sont disponibles.";
            return title;
        }
    }
}
