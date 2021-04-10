using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AltHealth.Data.Gateways.Repositories
{
    public class SupplimentRepository : RepositoryBase<tblSupplement>, ISupplimentRepository
    {
        public SupplimentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<spGetStockLevels_Result> GetStockLevels()
        {
            return DbContext.spGetStockLevels().ToList();
        }

        public List<spGetSuppliments_Result> GetSuppliments(string search = null)
        {
            return DbContext.spGetSuppliments(search).ToList();
        }
    }
}
