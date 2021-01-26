using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactsRegistration.Domain
{
	public class ContactDomain
	{
		[Key]
		public int? IdContact { get; set; }
		//Natural Person Fields
		public string Name { get; set; }
		public string CPF { get; set; }
		public DateTime? Birthday { get; set; }
		public Gender gender { get; set; }

		//Legal Person Fields
		public string CompanyName { get; set; }
		public string TradeName { get; set; }
		public string CNPJ { get; set; }
		//Common Fields
		public string ZipCode { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }

	}

	public enum Gender
	{
		Female = 1,
		Male = 2
	}
}
