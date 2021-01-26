using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class DeleteContactDomain : IDeleteContactDomain
	{
		public void Execute(int IdContact)
		{
			DomainBase.provider.GetService<IContactRepository>().Delete(IdContact);
		}
	}
}
