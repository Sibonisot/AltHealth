using AltHealth.Data.EF;
using System.Collections.Generic;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface IClientInfoRepository : IRepository<tblClientInfo>
    {
        /// <summary>
        /// Returns a list of Clients that  matches the provided search criteria
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        List<spGetClients_Result> GetClients(string search = null);
        /// <summary>
        /// Returns a Todays clients birthdays
        /// </summary>
        /// <returns></returns>
        List<spGetBirthDays_Result> GetBirthDays();
        /// <summary>
        /// Returns a list of top clients
        /// </summary>
        /// <returns></returns>
        List<spGetTopTenClients_Result> GetTopTenClients();
        /// <summary>
        /// Returns a list of Clients with no emails
        /// </summary>
        /// <returns></returns>
        List<spGetClientsWithNoEmails_Result> GetClientsWithNoEmails();
    }
}
