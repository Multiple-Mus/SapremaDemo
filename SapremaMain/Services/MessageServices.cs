using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SapremaMain.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        //public AuthMessageSender(IOptions<SMSoptions> optionsAccessor)
        //{
        //    OptionsSMS = optionsAccessor.Value;
        //}

        //public SMSoptions OptionsSMS { get; }  // set only via Secret Manager

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            Execute(Options.SendGridKey, subject, message, email).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("s.o.higgins@gmail.com", "Saprema"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
        //    // Plug in your SMS service here to send a text message.
        //    // Your Account SID from twilio.com/console
        //    var accountSid = OptionsSMS.accountSid;
        //    // Your Auth Token from twilio.com/console
        //    var authToken = OptionsSMS.authToken;

        //    TwilioClient.Init(accountSid, authToken);

        //    var msg = MessageResource.Create(
        //      to: new PhoneNumber(number),
        //      from: new PhoneNumber("+353 86 180 2077 "),
        //      body: message);

            return Task.FromResult(0);
        }
    }
}
