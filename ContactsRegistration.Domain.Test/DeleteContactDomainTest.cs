using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;

namespace ContactsRegistration.Domain.Test
{
	public class DeleteContactDomainTest: DomainTestBase
	{
		[Theory]
		[InlineData(1, 1)]
		public void ExecuteTest(int IdContact, int nrExpected)
		{
			var context = provider.GetRequiredService<ApiContext>();
			var domain = provider.GetService<IDeleteContactDomain>();

			this.AddTestContacts(context);
			domain.Execute(IdContact);
			Assert.Equal(nrExpected, context.Contact.Local.Count);
		}

	}
}
