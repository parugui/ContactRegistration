using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Interfaces
{
    public interface IInitializeDomain
    {
        void Initialize(ServiceProvider _provider);
    }
}
