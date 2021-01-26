using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace ContactsRegistration.Domain.Test
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfraTestDataServiceCollection(this IServiceCollection services)
        {
            
            services.AddScoped<IContactRepository, ContactRepository>();
       

            return services;
        }
    }
}
