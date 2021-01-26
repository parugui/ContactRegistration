using ContactsRegistration.Infra;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ContactsRegistration.Domain.Test
{
	public class ContactDomainTest : DomainTestBase
	{
		[Fact]
		public void Test1()
		{

			var context = provider.GetService<ApiContext>();
			this.AddTestContacts(context);
			var contact = context.Contact.ToListAsync().GetAwaiter();

			var Contacts = contact.GetResult();

			
			Assert.Equal(2, context.Contact.Local.Count);
		}

		


	}
}
