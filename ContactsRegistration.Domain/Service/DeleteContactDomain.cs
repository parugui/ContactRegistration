using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsRegistration.Domain.Service
{
	public class DeleteContactDomain : IDeleteContactDomain
	{
		private readonly IContactRepository _contactRepository;

        public DeleteContactDomain(IContactRepository contactRepository)
        {
			_contactRepository = contactRepository;

		}

		public void Execute(int IdContact)
		{
			_contactRepository.Delete(IdContact);
		}
	}
}
