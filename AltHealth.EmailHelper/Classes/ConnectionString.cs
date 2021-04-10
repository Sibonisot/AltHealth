using AltHealth.EmailHelper.Interfaces;
using System.Configuration;

namespace AltHealth.EmailHelper.Classes
{
    public class ConnectionString : IConnectionString
    {
        public EmailSettings EmailSettings => new EmailSettings
        {
            From = ConfigurationManager.AppSettings[nameof(EmailSettings.From)],
            SmtpServer = ConfigurationManager.AppSettings[nameof(EmailSettings.SmtpServer)],
            Username = ConfigurationManager.AppSettings[nameof(EmailSettings.Username)],
            Password = ConfigurationManager.AppSettings[nameof(EmailSettings.Password)],
            Port = int.Parse(ConfigurationManager.AppSettings[nameof(EmailSettings.Port)]),
            UseSsl = bool.Parse(ConfigurationManager.AppSettings[nameof(EmailSettings.UseSsl)])
        };
    }
}
