using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Domain.Service;

namespace ContactsRegistration.Domain
{
    public static class IServiceCollectionExtension
    {
        public static void AddDomainServiceCollection(this IServiceCollection services)
        {

            services.AddScoped<IInsertContactDomain, InsertContactDomain>();
            services.AddScoped<IListAllContactsDomain, ListAllContactsDomain>();
            services.AddScoped<IDeleteContactDomain, DeleteContactDomain>();
            services.AddScoped<ISelectContactDomain, SelectContactDomain>();
            services.AddScoped<IUpdateContactDomain, UpdateContactDomain>();
            
        }
    }
}
