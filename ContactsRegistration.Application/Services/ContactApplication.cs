using ContactsRegistration.Application.Dto;
using ContactsRegistration.Application.Interfaces;
using ContactsRegistration.Application.ViewModels;
using ContactsRegistration.Domain;
using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Application.Services
{
	public class ContactApplication : IContactApplication
	{
		private readonly IDeleteContactDomain _deleteContactDomain;
		private readonly IInsertContactDomain _insertContactDomain;
		private readonly IListAllContactsDomain _listAllContactsDomain;
		private readonly ISelectContactDomain _selectContactDomain;
		private readonly IUpdateContactDomain _updateContactDomain;

		public ContactApplication(IDeleteContactDomain deleteContactDomain, IInsertContactDomain insertContactDomain, IListAllContactsDomain listAllContactsDomain,
								ISelectContactDomain selectContactDomain, IUpdateContactDomain updateContactDomain)
        {
			_deleteContactDomain = deleteContactDomain;
			_insertContactDomain = insertContactDomain;
			_listAllContactsDomain = listAllContactsDomain;
			_selectContactDomain = selectContactDomain;
			_updateContactDomain = updateContactDomain;

		}


		/// <summary>
		/// Unregister Contact by id
		/// </summary>
		/// <param name="Id">Id of contact</param>
		/// <returns></returns>
		public ResponseDto UnregisterContact(int id)
		{
			_deleteContactDomain.Execute(id);

			return ResponseDto.ResponseSuccess();
		}

		public void Insert(vmContact contact)
		{
			var contactDomain = ConvertToDomainModel(contact);
			_insertContactDomain.Execute(contactDomain);
			
		}

		public List<vmContact> List()
		{
			List<ContactDomain> Contacts = _listAllContactsDomain.Execute();

			List<vmContact> ListContacts = new List<vmContact>();
			foreach(ContactDomain contact in Contacts)
			{
				ListContacts.Add(ConvertToViewModel(contact));
			}

			return ListContacts;
		}

		public vmContact Select(int IdContact)
		{
			ContactDomain contact = _selectContactDomain.Execute(IdContact);
			if (contact == null)
				return null;
			else
				return ConvertToViewModel(contact);
		}

		public void Update(vmContact contact)
		{
			ContactDomain contactDomain = ConvertToDomainModel(contact);
			_updateContactDomain.Execute(contactDomain);
		}

		private ContactDomain ConvertToDomainModel(vmContact contact)
		{
			ContactDomain contactDomain = new ContactDomain();
			contactDomain.IdContact = contact.IdContact;
			contactDomain.Name = contact.Name;
			contactDomain.CPF = contact.CPF;
			contactDomain.Birthday = string.IsNullOrEmpty(contact.Birthday) ? (DateTime?)null : Convert.ToDateTime(contact.Birthday);
			contactDomain.gender = (Gender)contact.gender;
			contactDomain.CompanyName = contact.CompanyName;
			contactDomain.TradeName = contact.TradeName;
			contactDomain.CNPJ = contact.CNPJ;
			contactDomain.ZipCode = contact.ZipCode;
			contactDomain.Country = contact.Country;
			contactDomain.State = contact.State;
			contactDomain.City = contact.City;
			contactDomain.AddressLine1 = contact.AddressLine1;
			contactDomain.AddressLine2 = contact.AddressLine2;

			return contactDomain;
		}

		private vmContact ConvertToViewModel(ContactDomain contact)
		{
			vmContact contactModel = new vmContact();
			contactModel.IdContact = contact.IdContact;
			contactModel.Name	= contact.Name;
			contactModel.CPF = contact.CPF;
			contactModel.Birthday = contact.Birthday == null ? "" : contact.Birthday.GetValueOrDefault().ToString("yyyy-MM-dd") ;
			contactModel.gender = Convert.ToInt32(contact.gender);
			contactModel.CompanyName = contact.CompanyName;
			contactModel.TradeName = contact.TradeName;
			contactModel.CNPJ = contact.CNPJ;
			contactModel.ZipCode = contact.ZipCode;
			contactModel.Country = contact.Country;
			contactModel.State = contact.State;
			contactModel.City = contact.City;
			contactModel.AddressLine1 = contact.AddressLine1;
			contactModel.AddressLine2 = contact.AddressLine2;

			return contactModel;
		}
	}
}
