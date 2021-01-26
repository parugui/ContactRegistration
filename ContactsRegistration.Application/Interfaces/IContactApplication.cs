using ContactsRegistration.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Application.Interfaces
{
	public interface IContactApplication
	{
		List<vmContact> List();
		vmContact Select(int IdContact);
		void Delete(int IdContact);
		void Insert(vmContact contact);
		void Update(vmContact contact);
	}
}
