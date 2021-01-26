using ContactsRegistration.Domain;
using ContactsRegistration.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ContactsRegistration.Infra.Data.Repository
{
	public class ContactRepository: IContactRepository 
	{
		private readonly ApiContext _context;

		public ContactRepository(ApiContext context)
		{
			_context = context;
		}

		public void Delete(int IdContact)
		{
			ContactDomain contact = _context.Contact.Find(IdContact);
			if (contact != null)
			{
				_context.Contact.Remove(contact);
				_context.SaveChanges();
			}
			else
			{
				throw new ArgumentException("Record not found.");
			}
		}

		public void Insert(ContactDomain contact)
		{
			_context.Contact.Add(contact);
			_context.SaveChanges();
		}

		public List<ContactDomain> List()
		{
			var contact = _context.Contact.ToArrayAsync().GetAwaiter();
			return contact.GetResult().ToList();
			
		}

		public ContactDomain Select(int IdContact)
		{
			var contact = _context.Contact
								.Where(c => c.IdContact == IdContact)
								.ToList();

			if (contact != null && contact.Count > 0)
				return contact.First();
			else
				return null;
		}

		public void Update(ContactDomain contact)
		{
			ContactDomain contactUpdt = _context.Contact.Find(contact.IdContact);
			if (contactUpdt != null)
			{
				contactUpdt.Name = contact.Name;
				contactUpdt.CPF = contact.CPF;
				contactUpdt.Birthday = contact.Birthday;
				contactUpdt.gender = contact.gender;
				contactUpdt.CompanyName = contact.CompanyName;
				contactUpdt.TradeName = contact.TradeName;
				contactUpdt.CNPJ = contact.CNPJ;
				contactUpdt.ZipCode = contact.ZipCode;
				contactUpdt.Country = contact.Country;
				contactUpdt.State = contact.State;
				contactUpdt.City = contact.City;
				contactUpdt.AddressLine1 = contact.AddressLine1;
				contactUpdt.AddressLine2 = contact.AddressLine2;

				_context.Update(contactUpdt);
			}
		}
	}
}
