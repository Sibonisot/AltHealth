using AltHealth.App.Utils;
using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using AltHealth.EmailHelper.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Extensions
{
    public static class CustomLinqExtensions
    {
        /// <summary>
        /// Returns true when grid has rows else false
        /// </summary>
        /// <param name="gridView"></param>
        /// <returns></returns>
        public static bool HasRows(this GridView gridView) => gridView.Rows.Count > 0;
       
        /// <summary>
        /// Validates the South African Identity Number
        /// Returns true if it's the valid id number else false
        /// </summary>
        /// <param name="idNumber">identity number string</param>
        /// <returns></returns>
        public static bool IsValidSouthAfricaIdNumber(this string idNumber)
        {
            if ((idNumber?.Length ?? 0) != 13) return false;
            if (!idNumber.All(char.IsDigit)) return false;

            //a) Add all the digits of the ID number in the odd positions (except for the last number, which is the control digit)
            List<KeyValuePair<int, int>> values = new List<KeyValuePair<int, int>>();
            int index = 1;
            for(var i = 0; i < idNumber.Length - 1; i++)
            {
                values.Add(new KeyValuePair<int, int>(index, int.Parse(idNumber[i].ToString())));
                index++;
            }
            var a = values.Where(p => p.Key % 2 > 0).Sum(p => p.Value);
            
            //b) Take all the even digits as one number and multiply that by 2:
            var b = int.Parse(string.Join(string.Empty, values.Where(p => p.Key % 2 == 0).Select(p => p.Value).ToList())) * 2;

            //c) Add the digits of this number together (in b)
            var digits = b.ToString();
            values = new List<KeyValuePair<int, int>>();
            for(var i = 0;i < digits.Length; i++)
            {
                values.Add(new KeyValuePair<int, int>(i, int.Parse(digits[i].ToString())));
            }
            var c = values.Sum(o => o.Value);
            //d) Add the answer of C to the answer of A
            var d = a + c;

            //e) Subtract the second character from D from 10, this number should now equal the control character           
            string controlCharacter = (10 - int.Parse(d.ToString().Substring(1,1))).ToString();

            return controlCharacter == idNumber.Substring(idNumber.Length - 1, 1);
        }
        /// <summary>
        /// Check if the QueryString exists on the page
        /// </summary>
        /// <param name="request"></param>
        /// <param name="queryStringName"></param>
        /// <returns></returns>
        public static bool HasQueryString(this HttpRequest request, string queryStringName) => request.QueryString[queryStringName] != null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsUpdate"></param>
        /// <param name="hiddenField"></param>
        /// <param name="textBox"></param>
        public static void SetControlsForCreateOrUpdate(bool IsUpdate, HiddenField hiddenField, TextBox textBox = null)
           
        {
            hiddenField.Value = IsUpdate.ToString();
            if (IsUpdate && textBox != null)
                textBox.Enabled = false;           
        }
        /// <summary>
        /// Get QueryString Value
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="queryStringName"></param>
        /// <returns></returns>
        public static string GetQueryString(this HttpRequest httpRequest, string queryStringName) => httpRequest.QueryString[queryStringName].ToString();
        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="response"></param>
        /// <param name="file"></param>
        public static void DownloadFile(this HttpResponse response, Tuple<string, string, byte[]> file)
        {
            if (file == null) return;

            response.Clear();
            MemoryStream ms = new MemoryStream(file.Item3);
            response.ContentType = file.Item2;
            response.AddHeader("content-disposition", $"attachment;filename={file.Item1}");
            response.Buffer = true;
            ms.WriteTo(response.OutputStream);
            response.End();
        }
        /// <summary>
        /// Send an email to Client
        /// </summary>
        /// <param name="invoiceNumber">Invoice Number</param>
        /// <param name="subject">Optional Email subject</param>
        /// <param name="content">Optional Email Content</param>
        /// <param name="templatePath">Invice Template path</param>
        /// <param name="repositoryWrapper"></param>
        /// <param name="emailSender"></param>
        /// <param name="textFormat"></param>
        /// <param name="CC"></param>
        /// <param name="BCC"></param>
        public static void SendEmail(string invoiceNumber,
                                     string templatePath,
                                     IRepositoryWrapper repositoryWrapper,
                                     IEmailSender emailSender,
                                     MimeKit.Text.TextFormat textFormat = MimeKit.Text.TextFormat.Html,
                                     IEnumerable<string> CC = null,
                                     IEnumerable<string> BCC = null,
                                     string subject = null,
                                     string content = null)
        {
            subject = subject ?? "Your Shopping Item(s)";
            content = content ?? "Hi <br/> Please see attached invoice for your shopping items.<br/><br/><br/> Regards,<br/>Alt Health Sales Team.";
            
            tblInv_Info inv_Info = repositoryWrapper.InvoiceInfo.GetById(invoiceNumber);

            if (string.IsNullOrWhiteSpace(inv_Info?.Client_id ?? string.Empty)) return;

            tblClientInfo tblClientInfo = repositoryWrapper.ClientInfo.GetById(inv_Info.Client_id);
            
            if (string.IsNullOrWhiteSpace(tblClientInfo?.C_Email ?? string.Empty)) return;

            Tuple<string, string, byte[]> invoice = DocumentHelper.GenerateInvoice(invoiceNumber, repositoryWrapper, templatePath);

            Dictionary<string, byte[]> attachments = new Dictionary<string, byte[]>
            {
                { invoice.Item1, invoice.Item3 }
            };

            emailSender.SendEmail(new EmailHelper.Classes.Message(new[] { tblClientInfo.C_Email },
                                                                  subject,
                                                                  content,
                                                                  CC,
                                                                  BCC,
                                                                  textFormat,
                                                                  attachments));
        }
    }
}