using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Infra;
using ContactsRegistration.Domain.Interfaces;

namespace ContactsRegistration.Domain.Test
{
	public class SelectContactDomainTest: DomainTestBase
	{
		[Fact]
		public void ExecuteTest()
		{
			var domain = provider.GetService<ISelectContactDomain>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);
			var contact = domain.Execute(1);
			Assert.Equal("Ruth Resende", contact.Name);

		}
	}
}
