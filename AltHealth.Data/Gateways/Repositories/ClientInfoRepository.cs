using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AltHealth.Data.Gateways.Repositories
{
    public class ClientInfoRepository : RepositoryBase<tblClientInfo>, IClientInfoRepository
    {
        public ClientInfoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<spGetBirthDays_Result> GetBirthDays()
        {
            return DbContext.spGetBirthDays().ToList();
        }

        public List<spGetClients_Result> GetClients(string search = null)
        {
            return DbContext.spGetClients(search).ToList();
        }

        public List<spGetClientsWithNoEmails_Result> GetClientsWithNoEmails()
        {
            return DbContext.spGetClientsWithNoEmails().ToList();
        }

        public List<spGetTopTenClients_Result> GetTopTenClients()
        {
            return DbContext.spGetTopTenClients().ToList();
        }
    }
}
