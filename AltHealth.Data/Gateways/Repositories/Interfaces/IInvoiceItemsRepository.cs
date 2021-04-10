using AltHealth.Data.EF;
using System.Collections.Generic;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface IInvoiceItemsRepository : IRepository<tblInv_items>
    {
        List<spGetCartItems_Result> GetCartItems(string invoiceNo, string clientId);
    }
}
