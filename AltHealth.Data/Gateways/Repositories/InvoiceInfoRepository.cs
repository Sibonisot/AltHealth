using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AltHealth.Data.Gateways.Repositories
{
    public class InvoiceInfoRepository : RepositoryBase<tblInv_Info>, IInvoiceInfoRepository
    {
        public InvoiceInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public string GenerateInvoiceNumber()
        {
            return DbContext.spGenerateInvoiceNumber().FirstOrDefault();
        }

        public List<spGetInvoices_Result> GetInvoices(string search = null)
        {
            return DbContext.spGetInvoices(search).ToList();
        }

        public List<spGetPurchaseStats_Result> GetPurchaseStats(int? startYear = null)
        {
            return DbContext.spGetPurchaseStats(startYear).ToList();
        }

        public List<spGetUnpaidInvoices_Result> GetUnpaidInvoices()
        {
            return DbContext.spGetUnpaidInvoices().ToList();
        }
    }
}
