using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;

namespace AltHealth.Data.Gateways.Repositories
{
    public class SupplierRepository : RepositoryBase<tblSupplier_info>, ISupplierRepository
    {
        public SupplierRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<spGetSuppliers_Result> GetSuppliers(string search = null)
        {
            return DbContext.spGetSuppliers(search).ToList();
        }
    }
}
