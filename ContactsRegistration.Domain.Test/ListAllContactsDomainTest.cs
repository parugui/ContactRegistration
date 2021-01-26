using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;

namespace ContactsRegistration.Domain.Test
{
	public class ListAllContactsDomainTest: DomainTestBase
	{
		[Fact]
		public void ExecuteTest()
		{
			var repo = provider.GetService<IListAllContactsDomain>();
			var context = provider.GetService<ApiContext>();

			this.AddTestContacts(context);
			repo.Execute();
			Assert.Equal(2, context.Contact.Local.Count);

		}
	}
}
