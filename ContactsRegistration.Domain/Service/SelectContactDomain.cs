using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class SelectContactDomain : ISelectContactDomain
	{
		private readonly IContactRepository _contactRepository;

		public SelectContactDomain(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;

		}

		public NaturalPerson Execute(int IdContact)
		{
			return _contactRepository.Select(IdContact);
		}
	}
}
