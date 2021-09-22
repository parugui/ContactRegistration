using ContactsRegistration.Domain;
using ContactsRegistration.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Application
{
    public static class IServiceCollectionConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                        ServiceLifetime.Scoped,
                        ServiceLifetime.Scoped);

            services.AddDomainServiceCollection();
            services.AddInfraServiceCollection();
        }
    }
}
