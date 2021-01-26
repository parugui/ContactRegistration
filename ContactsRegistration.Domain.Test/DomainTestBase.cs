using ContactsRegistration.Domain;
using ContactsRegistration.Domain.Interfaces;
using ContactsRegistration.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ContactsRegistration.Domain.Test
{
    public class DomainTestBase
    {
        public ServiceProvider provider { get; private set; }

        public DomainTestBase()
        {

            var service = new ServiceCollection();

            service.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
            ServiceLifetime.Scoped,
            ServiceLifetime.Scoped);

            service.AddDomainServiceCollection();
            //service.AddInfraTestDataServiceCollection(); //MOCK
            service.AddInfraServiceCollection();

            provider = service.BuildServiceProvider();

            provider.GetService<IInitializeDomain>().Initialize(provider);

        }

        public void AddTestContacts(ApiContext context)
		{
            var contact1 = context.Contact.Find(1);
            if (contact1 == null)
            {
                context.Contact.Add(new ContactDomain
                {
                    IdContact = 1,
                    Name = "Ruth Resende",
                    CPF = "34457812548",
                    gender = Gender.Female
                });
            }

            var contact2 = context.Contact.Find(2);
            if (contact2 == null)
            {
                context.Contact.Add(new ContactDomain
                {
                    IdContact = 2,
                    Name = "Paulo Resende",
                    CPF = "25546722339",
                    gender = Gender.Male
                });
            }

            context.SaveChanges();

        }

    }
}
