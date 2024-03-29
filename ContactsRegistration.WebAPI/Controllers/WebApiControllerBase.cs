﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using ContactsRegistration.Application.Services;

namespace ContactsRegistration.WebAPI.Controllers
{
    public class WebApiControllerBase : ControllerBase
    {        
        public IConfiguration Configuration { get; private set; }

        public WebApiControllerBase()
        {

            ConfigurationBase();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void ConfigurationBase()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(result);
        }

        protected IActionResult Error(string errorMessage)
        {
            return base.BadRequest(errorMessage);
        }
    }
}
