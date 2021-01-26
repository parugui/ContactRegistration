using ContactsRegistration.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsRegistration.Infra
{
	public class ApiContext: DbContext
	{
		public ApiContext(DbContextOptions<ApiContext> options) : base(options)
		{ }

		public DbSet<ContactDomain> Contact { get; set; }
	}
}
