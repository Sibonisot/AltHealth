using AltHealth.EmailHelper.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Linq;

namespace AltHealth.EmailHelper.Classes
{
    public class EmailSender : IEmailSender
    {
        private readonly IConnectionString _connectionString;

        public EmailSender(IConnectionString connectionString)
        {
            _connectionString = connectionString;
        }
        public void SendEmail(Message message)
        {
            Send(CreateMessage(message));
        }
        private MimeMessage CreateMessage(Message message)
        {
            var bodyBuilder = new BodyBuilder
            {
                TextBody = message.EmailFormat == MimeKit.Text.TextFormat.Text ? message.Content : string.Empty,
                HtmlBody = message.EmailFormat == MimeKit.Text.TextFormat.Html ? message.Content : string.Empty
            };

            if (message.Attachments?.Count > 0)
                message.Attachments.ToList().ForEach(attachment => bodyBuilder.Attachments.Add(attachment.Key, attachment.Value));

            var emailMessage = new MimeMessage
            {
                Subject = message.Subject,
                Body = bodyBuilder.ToMessageBody()
            };

            emailMessage.From.Add(MailboxAddress.Parse(_connectionString.EmailSettings.From));
            emailMessage.To.AddRange(message.To);

            if (message.CC?.Count > 0)
                emailMessage.Cc.AddRange(message.CC);
            if (message.BCC?.Count > 0)
                emailMessage.Bcc.AddRange(message.BCC);

            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using(SmtpClient client = new SmtpClient())
            {
                try
                {
                    client.Connect(_connectionString.EmailSettings.SmtpServer, _connectionString.EmailSettings.Port, _connectionString.EmailSettings.UseSsl);
                    if (client.AuthenticationMechanisms.Count > 0)
                        client.Authenticate(_connectionString.EmailSettings.Username, _connectionString.EmailSettings.Password);

                    client.Send(message);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
