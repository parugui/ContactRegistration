using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class ListAllContactsDomain : IListAllContactsDomain
	{
		public List<ContactDomain> Execute()
		{
			return DomainBase.provider.GetService<IContactRepository>().List();
		}
	}
}
