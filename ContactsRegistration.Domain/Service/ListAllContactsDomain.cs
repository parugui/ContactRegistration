using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class ListAllContactsDomain : IListAllContactsDomain
	{
		private readonly IContactRepository _contactRepository;

		public ListAllContactsDomain(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;

		}

		public List<ContactDomain> Execute()
		{
			return _contactRepository.List();
		}
	}
}
