using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Domain.Interfaces
{
	public interface ISelectContactDomain
	{
		NaturalPerson Execute(int IdContact);
	}
}
