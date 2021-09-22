using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ContactsRegistration.Application.Interfaces;
using ContactsRegistration.Application.ViewModels;
using ContactsRegistration.Application.Dto;

namespace ContactsRegistration.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : WebApiControllerBase
	{
		private readonly IContactApplication _contactApplication;

		public ContactController(IContactApplication contactApplication)
		{
			_contactApplication = contactApplication;
		}

		[HttpGet("{id}")]
		public IActionResult GetContactById(int id)
		{
			vmResult result = new vmResult();
			try
			{
				vmContact contact = _contactApplication.Select(id);
				result.Data = contact;
				if (contact == null)
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

		[HttpGet()]
		public IActionResult GetAllContacts()
		{
			vmResult result = new vmResult();
			try
			{
				List<vmContact> Contacts = _contactApplication.List();
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

		[HttpDelete("{id}")]
		public ResponseDto UnregisterContact(int id) => _contactApplication.UnregisterContact(id);

		[HttpPut()]
		public IActionResult EditContact(vmContact contact)
		{
			vmResult result = new vmResult();
			try
			{
				_contactApplication.Update(contact);
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
		public IActionResult RegisterContact(vmContact contact)
		{
			vmResult result = new vmResult();
			try
			{
				_contactApplication.Insert(contact);

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
