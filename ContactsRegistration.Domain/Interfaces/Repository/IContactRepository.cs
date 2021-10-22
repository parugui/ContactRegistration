using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Domain.Interfaces
{
	public interface IContactRepository
	{
		List<NaturalPerson> List();
		NaturalPerson Select(int IdContact);
		void Delete(int IdContact);
		void Insert(NaturalPerson contact);
		void Update(NaturalPerson contact);

	}
}
