using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;

namespace ContactsRegistration.Domain.Test
{
	public class UpdateContactDomainTest: DomainTestBase
	{
		[Fact]
		public void ExecuteTest()
		{
			/*
			var repo = provider.GetService<IUpdateContactDomain>();
			var context = provider.GetService<ApiContext>();


			ContactDomain contact = new ContactDomain
			{
				IdContact = 1,
				Name = "Guilherme Resende",
				CPF = "55896541274",
				gender = Gender.Male
			};

			repo.Execute(contact);

			var contactUpdate = context.Contact.Find(1);
			Assert.Equal("Guilherme Resende", contactUpdate.Name);
			*/
		}
	}
}
