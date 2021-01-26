using ContactsRegistration.Domain;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Application.Services
{
	public class ApplicationBase
	{
		public ServiceProvider provider { get; private set; }
		public ApplicationBase()
		{
			var service = new ServiceCollection();
			service.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
		    ServiceLifetime.Scoped,
		    ServiceLifetime.Scoped);

			service.AddDomainServiceCollection();
			service.AddInfraServiceCollection();
			provider = service.BuildServiceProvider();

		}
		public T GetService<T>()
		{
			provider.GetService<IInitializeDomain>().Initialize(provider);
			return provider.GetService<T>();
		}
	}
}
