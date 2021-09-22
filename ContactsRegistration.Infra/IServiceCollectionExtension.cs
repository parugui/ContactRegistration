using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace ContactsRegistration.Infra
{
    public static class IServiceCollectionExtension
    {
        public static void AddInfraServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            
        }
    }
}
