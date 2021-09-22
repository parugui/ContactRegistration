using ContactsRegistration.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;



namespace ContactsRegistration.Application.Services
{
    public static class IServiceCollectionExtension
    {
        public static void AddApplicationServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IContactApplication, ContactApplication>();

        }
    }
}
