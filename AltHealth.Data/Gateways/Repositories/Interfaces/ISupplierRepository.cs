using AltHealth.Data.EF;
using System.Collections.Generic;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface ISupplierRepository : IRepository<tblSupplier_info>
    {
        List<spGetSuppliers_Result> GetSuppliers(string search = null);
    }
}
