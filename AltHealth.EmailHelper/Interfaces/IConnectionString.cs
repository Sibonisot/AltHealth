using AltHealth.EmailHelper.Classes;

namespace AltHealth.EmailHelper.Interfaces
{
    public interface IConnectionString
    {
        EmailSettings EmailSettings { get; }
    }
}
