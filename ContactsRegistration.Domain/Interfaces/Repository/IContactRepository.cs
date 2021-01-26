using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Domain.Interfaces
{
	public interface IContactRepository
	{
		List<ContactDomain> List();
		ContactDomain Select(int IdContact);
		void Delete(int IdContact);
		void Insert(ContactDomain contact);
		void Update(ContactDomain contact);

	}
}
