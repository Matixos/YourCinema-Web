using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using Kino.Business.Entity;
using Kino.Business.Dal;
using Kino.Business.Common;
using System.Web.Configuration;

namespace Kino.Business.Services
{
    public static class MailingService
    {
        /// <summary>
        /// Sends the confirmation e-mail.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void SendConfirmationEmail(User user)
        {
            string confirmationToken = user.ActiveToken;
            
            string verifyUrl = (WebConfigurationManager.AppSettings["deployUrl"] ?? HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority))
                + "/Account/Verify?token=" + confirmationToken;

            var message = new MailMessage("xxx@yyy.com", user.Email)
            {
                Subject = Localization.ConfirmationEmailSubject,
                Body =  Localization.ConfirmationEmailBody + verifyUrl
            };

            SmtpClient client = new SmtpClient();
            client.SendAsync(message, null);
        }

        /// <summary>
        /// Sends an e-mail with recovered password for user.
        /// </summary>
        /// <param name="email">The user's e-mail.</param>
        /// <param name="newPassword">The new password for user.</param>
        public static void SendRecoveredPasswordEmail(string email, string newPassword)
        {
            string passwordIs = "password: " + Environment.NewLine;

            var message = new MailMessage("xxx@yyy.com", email)
            {
                Subject = Localization.RecoveredPasswordEmailSubject,
                Body = Localization.RecoveredPasswordEmailBody.Insert(Localization.RecoveredPasswordEmailBody.IndexOf(passwordIs) + passwordIs.Length, newPassword)
            };

            var client = new SmtpClient();
            client.SendAsync(message, null);
        }
    }
}
