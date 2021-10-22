using ContactsRegistration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactsRegistration.Infra;

namespace ContactsRegistration.Domain.Test
{
	public class ContactRepositoryTest: DomainTestBase
	{

		[Fact]
		public void ListTest()
		{
			var repo = provider.GetService<IContactRepository>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			var contact = repo.List();
			Assert.Equal(2, contact.Count);

		}

		[Fact]
		public void SelectTest()
		{
			var repo = provider.GetService<IContactRepository>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			var contact = repo.Select(1);
			Assert.Equal("Ruth Resende", contact.Name);
		}

		[Fact]
		public void InsertTest()
		{
			var repo = provider.GetService<IContactRepository>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			NaturalPerson contact = new NaturalPerson
			{
				IdContact = 3,
				Name = "Guilherme Resende",
				CPF = "55896541274",
				gender = Gender.Male
			};

			repo.Insert(contact);
			Assert.Equal(3, context.Contact.Local.Count);

		}

		[Theory]
		[InlineData(1, 1)]
		public void DeleteTest(int IdContact, int nrExpected)
		{
			var repo = provider.GetService<IContactRepository>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			repo.Delete(IdContact);
			Assert.Equal(nrExpected, context.Contact.Local.Count);
		}

		[Fact]
		public void UpdateTest()
		{
			var repo = provider.GetService<IContactRepository>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			NaturalPerson contact1 = context.Contact.Find(1);
			contact1.Name = "Maria Ruth da Silva Resende";
			contact1.AddressLine1 = "Rua Sinval Duarte Pereira, 32";
			repo.Update(contact1);

			Assert.Equal("Maria Ruth da Silva Resende", context.Contact.Find(1).Name);
		}
	}
}
