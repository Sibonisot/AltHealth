using AltHealth.Data.EF;
using AltHealth.Data.Gateways.Repositories.Interfaces;

namespace AltHealth.Data.Gateways.Repositories
{
    public class DbFactory : Disposable, IDbFactory
       
    {
        HealthEntities dbContext;
        public HealthEntities Init() => dbContext = dbContext ?? new HealthEntities();

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
