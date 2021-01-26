using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class UpdateContactDomain : IUpdateContactDomain
	{
		public void Execute(ContactDomain contact)
		{
			DomainBase.provider.GetService<IContactRepository>().Update(contact);
		}
	}
}
