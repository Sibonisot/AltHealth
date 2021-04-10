using AltHealth.EmailHelper.Classes;

namespace AltHealth.EmailHelper.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
