using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;

namespace AltHealth.Data.Gateways.Repositories
{
    public class ReferenceRepository : RepositoryBase<tblReference>, IReferenceRepository
    {
        public ReferenceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
