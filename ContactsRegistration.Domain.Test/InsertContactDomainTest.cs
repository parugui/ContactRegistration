using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;


namespace ContactsRegistration.Domain.Test
{
	public class InsertContactDomainTest: DomainTestBase
	{
		[Fact]
		public void ExecuteTest()
		{
			var repo = provider.GetService<IInsertContactDomain>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);

			ContactDomain contact = new ContactDomain
			{
				IdContact = 3,
				Name = "Guilherme Resende",
				CPF = "55896541274",
				gender = Gender.Male
			};

			repo.Execute(contact);
			Assert.Equal(3, context.Contact.Local.Count);
		}
	}
}
