using MimeKit;
using MimeKit.Text;
using System.Collections.Generic;
using System.Linq;

namespace AltHealth.EmailHelper.Classes
{
    public class Message
    {
        /// <summary>
        /// To email addresses
        /// </summary>
        public List<MailboxAddress> To { get; set; }
        /// <summary>
        /// Cc email addresses
        /// </summary>
        public List<MailboxAddress> CC { get; set; }
        /// <summary>
        /// BCC email addresses
        /// </summary>
        public List<MailboxAddress> BCC { get; set; }
        /// <summary>
        /// Email Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Email Body
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Email Format - default Html
        /// </summary>
        public TextFormat EmailFormat { get; set; }
        /// <summary>
        /// Email attachments: key - filename, value - file binary
        /// </summary>
        public Dictionary<string, byte[]> Attachments { get; set; }
        /// <summary>
        /// Overloaded constructor for Massage
        /// </summary>
        /// <param name="to">To email addresses</param>
        /// <param name="subject">Email subject</param>
        /// <param name="content">Email body</param>
        /// <param name="cc">Optional CC email address - default null</param>
        /// <param name="bcc">Optional BCC  Email addresses - default null</param>
        /// <param name="emailFormat">Otions Email format enum - default Html</param>
        /// <param name="attachments">Optional Email attachments </param>
        public Message(IEnumerable<string> to, string subject, string content, IEnumerable<string> cc = null, IEnumerable<string> bcc = null, TextFormat emailFormat = TextFormat.Html, Dictionary<string, byte[]> attachments = null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(email => MailboxAddress.Parse(email)));

            Subject = subject;
            Content = content;
            EmailFormat = emailFormat;

            if (cc != null)
            {
                CC = new List<MailboxAddress>();
                CC.AddRange(cc.Select(x => MailboxAddress.Parse(x)));
            }
            if (bcc != null)
            {
                BCC = new List<MailboxAddress>();
                BCC.AddRange(bcc.Select(x => MailboxAddress.Parse(x)));
            }
            if (attachments != null)
            {
                Attachments = new Dictionary<string, byte[]>();
                attachments.ToList().ForEach(x => Attachments.Add(x.Key, x.Value));
            }
        }
    }
}
