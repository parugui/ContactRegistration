using ContactsRegistration.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace ContactsRegistration.Domain
{
    public class InitializeDomain : IInitializeDomain
    {
        public void Initialize(ServiceProvider _provider)
        {
            if (DomainBase.provider == null)
                DomainBase.provider = _provider;
        }
    }
}
