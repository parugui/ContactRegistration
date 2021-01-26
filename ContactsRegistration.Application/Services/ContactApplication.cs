using ContactsRegistration.Application.Interfaces;
using ContactsRegistration.Application.ViewModels;
using ContactsRegistration.Domain;
using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Application.Services
{
	public class ContactApplication : ApplicationBase, IContactApplication
	{
		public void Delete(int IdContact)
		{
			var domain = GetService<IDeleteContactDomain>();
			domain.Execute(IdContact);
		}

		public void Insert(vmContact contact)
		{
			var domain = GetService<IInsertContactDomain>();
			var contactDomain = ConvertToDomainModel(contact);
			domain.Execute(contactDomain);
			
		}

		public List<vmContact> List()
		{
			var domain = GetService<IListAllContactsDomain>();
			List<ContactDomain> Contacts = domain.Execute();

			List<vmContact> ListContacts = new List<vmContact>();
			foreach(ContactDomain contact in Contacts)
			{
				ListContacts.Add(ConvertToViewModel(contact));
			}

			return ListContacts;
		}

		public vmContact Select(int IdContact)
		{
			var domain = GetService<ISelectContactDomain>();
			ContactDomain contact = domain.Execute(IdContact);
			if (contact == null)
				return null;
			else
				return ConvertToViewModel(contact);
		}

		public void Update(vmContact contact)
		{
			var domain = GetService<IUpdateContactDomain>();
			ContactDomain contactDomain = ConvertToDomainModel(contact);
			domain.Execute(contactDomain);
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
