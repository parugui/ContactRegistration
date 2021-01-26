using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Domain.Interfaces
{
	public interface IDeleteContactDomain
	{
		void Execute(int IdContact);
	}
}
