using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class UpdateContactDomain : IUpdateContactDomain
	{
		private readonly IContactRepository _contactRepository;

		public UpdateContactDomain(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;

		}

		public void Execute(NaturalPerson contact)
		{
			_contactRepository.Update(contact);
		}
	}
}
