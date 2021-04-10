using AltHealth.Data.EF;
using System.Collections.Generic;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface ISupplimentRepository : IRepository<tblSupplement>
    {
        List<spGetSuppliments_Result> GetSuppliments(string search = null);
        List<spGetStockLevels_Result> GetStockLevels();
    }
}
