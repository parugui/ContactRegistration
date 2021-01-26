using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class SelectContactDomain : ISelectContactDomain
	{
		public ContactDomain Execute(int IdContact)
		{
			return DomainBase.provider.GetService<IContactRepository>().Select(IdContact);
		}
	}
}
