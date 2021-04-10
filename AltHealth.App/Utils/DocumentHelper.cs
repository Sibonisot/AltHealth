using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using Novacode;

namespace AltHealth.App.Utils
{
    public static class DocumentHelper
    {
        /// <summary>
        /// Convert word document to PDF
        /// </summary>
        /// <param name="docxFile"></param>
        /// <param name="pdfFile"></param>
        /// <returns></returns>
        public static Tuple<string, string, byte[]> ConvertToPDF(string docxFile, string pdfFile)
        {
            Tuple<string, string, byte[]> file = new Tuple<string, string, byte[]>("", "", Array.Empty<byte>());
            Document document = new Document();
            document.LoadFromFile(docxFile);
            document.SaveToFile(pdfFile, FileFormat.PDF);
            if (File.Exists(pdfFile))
            {
                file = new Tuple<string, string, byte[]>(Path.GetFileName(pdfFile), MimeMapping.GetMimeMapping(pdfFile), File.ReadAllBytes(pdfFile));
                // delete new invoice files word and pdf
                File.Delete(docxFile);
                File.Delete(pdfFile);
            }
            return file;
        }
        /// <summary>
        /// Generate Invoince and convert it to PDF
        /// T1 - File name
        /// T2 - Content Type
        /// T3 - Byte array
        /// </summary>
        /// <param name="invoiceNo"></param>
        /// <param name="repositoryWrapper"></param>
        /// <param name="templatePath"></param>
        /// <returns></returns>
        public static Tuple<string, string, byte[]> GenerateInvoice(string invoiceNo, IRepositoryWrapper repositoryWrapper, string templatePath)
        {
            var templateFile = $"{templatePath}{ConfigurationManager.AppSettings["FileName"]}";

            if (string.IsNullOrEmpty(templateFile))
                throw new Exception("Invoice Template file could not be found");

            if (!File.Exists(templateFile))
                throw new Exception($"Template file does not exists on location:{Path.GetDirectoryName(templateFile)}");

            tblInv_Info inv_Info = repositoryWrapper.InvoiceInfo.GetById(invoiceNo);

            if (inv_Info == null) throw new Exception($"No Invoice exists with invoice Number:{invoiceNo}");
           
            tblClientInfo clientInfo = repositoryWrapper.ClientInfo.GetById(inv_Info.Client_id);
            
            List<spGetCartItems_Result> cartItems = repositoryWrapper.InvoiceItems.GetCartItems(invoiceNo, inv_Info.Client_id);

            string fileName = string.Empty;

            using(DocX document = DocX.Load(templateFile))
            {
                ReplaceClientDetails(document, clientInfo);

                ReplaceInvoiceDetails(document, inv_Info);

                ReplaceInvoiceItems(document, cartItems, inv_Info.Inv_Paid);

                //save the new file
                fileName = $@"{Path.GetDirectoryName(templateFile)}\{invoiceNo}.docx";

                document.SaveAs(fileName);
            }
            var fileExtension = Path.GetExtension(fileName);
            
            if (string.IsNullOrWhiteSpace(fileExtension)) return null;
            
            if (!new[] { ".doc", ".docx" }.Contains(fileExtension)) return null;

            var pdfFileName = $@"{Path.GetDirectoryName(fileName)}\{Path.GetFileName(fileName).Replace(fileExtension, ".pdf")}";

            return ConvertToPDF(fileName, pdfFileName);
        }
        /// <summary>
        /// Replace Client details
        /// </summary>
        /// <param name="document"></param>
        /// <param name="clientInfo"></param>
        private static void ReplaceClientDetails(DocX document, tblClientInfo clientInfo)
        {
            document.ReplaceText("{CName}", clientInfo.C_name);
            document.ReplaceText("{CSurname}", clientInfo.C_surname);
            document.ReplaceText("{Address}", $"{clientInfo.Address} {clientInfo.Code}");
            document.ReplaceText("{THome}", clientInfo.C_Tel_H);
            document.ReplaceText("{TWork}", clientInfo.C_Tel_W);
            document.ReplaceText("{Mobile}", clientInfo.C_Tel_Cell ?? string.Empty);
            document.ReplaceText("{Email}", clientInfo.C_Email ?? string.Empty);
        }
        /// <summary>
        /// Replace Invoice Detauils
        /// </summary>
        /// <param name="document"></param>
        /// <param name="inv_Info"></param>
        private static void ReplaceInvoiceDetails(DocX document, tblInv_Info inv_Info)
        {
            document.ReplaceText("{InvNum}", inv_Info.Inv_Num);
            document.ReplaceText("{InvDate}", inv_Info.Inv_Date.ToDateFormat());
            document.ReplaceText("{PaymentDate}", inv_Info.Inv_Paid ? "Payment Date" : string.Empty);
            document.ReplaceText("{PDate}", inv_Info.Inv_Paid ? $": {inv_Info.Inv_Paid_Date.FromNullableDateToDateFormat()}": string.Empty);
        }
        /// <summary>
        /// Replace Invoice Items
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="cartItems">List of invoice items</param>
        /// <param name="invoicePaid">Invoice Paid</param>
        private static void ReplaceInvoiceItems(DocX document, List<spGetCartItems_Result> cartItems, bool invoicePaid)
        {
            var invoiceItems = cartItems.Select(cart => new
            {
                cart.Supplement_Description,
                cart.Item_Quantity,
                Price = cart.Item_Price.AddCurrency(),
                Quantity = cart.Item_Quantity.ToString(),
                SubTotal = (cart.SubTotal ?? 0M).AddCurrency()
            }).ToList();    
            
            document.ReplaceText("{Description}", string.Join(Environment.NewLine, invoiceItems.Select(p => p.Supplement_Description).ToList()));
            document.ReplaceText("{Quantity}", string.Join(Environment.NewLine, invoiceItems.Select(p => p.Quantity).ToList()));
            document.ReplaceText("{Price}", string.Join(Environment.NewLine, invoiceItems.Select(p => p.Price).ToList()));
            document.ReplaceText("{Amount}", string.Join(Environment.NewLine, invoiceItems.Select(p => p.SubTotal).ToList()));

            decimal subTotal = cartItems.Sum(p => p.SubTotal) ?? 0M;           
            
            decimal vat = subTotal * (decimal.Parse(ConfigurationManager.AppSettings["VAT"]) / 100M);
            
            document.ReplaceText("{SubTotal}", (subTotal - vat).AddCurrency());
            document.ReplaceText("{Balance}", invoicePaid ? "Total" : "Balance Due");
            document.ReplaceText("{Vat}", vat.AddCurrency());
            document.ReplaceText("{Total}", subTotal.AddCurrency());            
        }
        /// <summary>
        /// Convert decimal to string and add currency format
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currencyFormat"></param>
        /// <returns></returns>
        public static string AddCurrency(this decimal amount, string currencyFormat = "R0.00") => amount.ToString(currencyFormat);
        /// <summary>
        /// Convert nullable DateTime to specified format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FromNullableDateToDateFormat(this DateTime? dateTime, string format = "dd-MM-yyyy") => dateTime == null ? string.Empty : dateTime?.ToString(format);
        /// <summary>
        /// convert  DateTime to specified format
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToDateFormat(this DateTime dateTime, string format = "dd-MM-yyyy") => dateTime.ToString(format);
    }
}