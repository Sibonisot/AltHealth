using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AltHealth.Data.Gateways.Repositories
{
    public class InvoiceItemsRepository : RepositoryBase<EF.tblInv_items>, IInvoiceItemsRepository
    {
        public InvoiceItemsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<spGetCartItems_Result> GetCartItems(string invoiceNo, string clientId)
        {
            return DbContext.spGetCartItems(invoiceNo, clientId).ToList();
        }
    }
}
