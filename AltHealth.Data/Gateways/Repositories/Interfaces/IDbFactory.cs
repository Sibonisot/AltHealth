using AltHealth.Data.EF;

namespace AltHealth.Data.Gateways.Repositories.Interfaces
{
    public interface IDbFactory
    {
        HealthEntities Init();
    }
}
