using AltHealth.Data.EF;
using System.Collections.Generic;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface IInvoiceInfoRepository : IRepository<tblInv_Info>
    {
        /// <summary>
        /// Generate Invoice Number
        /// </summary>
        /// <returns></returns>
        string GenerateInvoiceNumber();
        /// <summary>
        /// Get a list of Unpaid Invoices
        /// </summary>
        /// <returns></returns>
        List<spGetUnpaidInvoices_Result> GetUnpaidInvoices();
        /// <summary>
        /// Get a list of Purchases that has been performed during years
        /// </summary>
        /// <param name="startYear"></param>
        /// <returns></returns>
        List<spGetPurchaseStats_Result> GetPurchaseStats(int? startYear = null);
        /// <summary>
        /// Returns a list of invoices
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<spGetInvoices_Result> GetInvoices(string search = null);
    }
}
