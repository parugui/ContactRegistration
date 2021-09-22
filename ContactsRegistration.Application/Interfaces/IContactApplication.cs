using ContactsRegistration.Application.Dto;
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

		/// <summary>
		/// Unregister Contact by id
		/// </summary>
		/// <param name="Id">Id of contact</param>
		/// <returns></returns>
		ResponseDto UnregisterContact(int id);
		void Insert(vmContact contact);
		void Update(vmContact contact);
	}
}
