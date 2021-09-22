using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class InsertContactDomain : IInsertContactDomain
	{
		private readonly IContactRepository _contactRepository;

		public InsertContactDomain(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;

		}

		public void Execute(ContactDomain contact)
		{
			_contactRepository.Insert(contact);
		}
	}
}
