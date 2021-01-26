using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Application.Interfaces;
using ContactsRegistration.Application.ViewModels;

namespace ContactsRegistration.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController: WebApiControllerBase
	{
		[HttpGet()]
		public IActionResult GET(int IdContact)
		{
			vmResult result = new vmResult();
			try
			{
				var service = Provider.GetService<IContactApplication>();
				vmContact contact = service.Select(IdContact);
				result.Data = contact;
				if (contact == null)
					result.FriendlyErrorMessage = "No Records Found!";

				return Ok(result);
			}
			catch(Exception ex)
			{
				result.FriendlyErrorMessage = "Unexpected System Error";
				result.StackTrace = ex.Message + "/n" + ex.StackTrace;
				return BadRequest(result);
			}

		}

		[HttpGet("List")]
		public IActionResult List()
		{
			vmResult result = new vmResult();
			try
			{
				var service = Provider.GetService<IContactApplication>();
				List<vmContact> Contacts = service.List();
				result.Data = Contacts;
				if (Contacts == null || Contacts.Count == 0)
					result.FriendlyErrorMessage = "No Records Found!";

				return Ok(result);
			}
			catch (Exception ex)
			{
				result.FriendlyErrorMessage = "Unexpected System Error";
				result.StackTrace = ex.Message + "/n" + ex.StackTrace;
				return BadRequest(result);
			}

		}

		[HttpDelete()]
		public IActionResult Delete(int IdContact)
		{
			vmResult result = new vmResult();
			try
			{
				var service = Provider.GetService<IContactApplication>();
				service.Delete(IdContact);
				return Ok();
			}
			catch (ArgumentException aex)
			{
				result.FriendlyErrorMessage = aex.Message;
				return Ok(result);
			}
			catch (Exception ex)
			{
				result.FriendlyErrorMessage = "Unexpected System Error";
				result.StackTrace = ex.Message + "/n" + ex.StackTrace;
				return BadRequest(result);
			}
			

		}

		[HttpPut()]
		public IActionResult PUT(vmContact contact)
		{
			vmResult result = new vmResult();
			try
			{
				var service = Provider.GetService<IContactApplication>();
				service.Update(contact);
				return Ok();
			}
			catch (Exception ex)
			{
				result.FriendlyErrorMessage = "Unexpected System Error";
				result.StackTrace = ex.Message + "/n" + ex.StackTrace;
				return BadRequest(result);
			}
		}

		[HttpPost()]
		public IActionResult POST(vmContact contact)
		{
			vmResult result = new vmResult();
			try
			{
				var service = Provider.GetService<IContactApplication>();
				service.Insert(contact);

				return Ok();
			}
			catch (Exception ex)
			{
				result.FriendlyErrorMessage = "Unexpected System Error";
				result.StackTrace = ex.Message + "/n" + ex.StackTrace;
				return BadRequest(result);
			}
		}

	}
}
