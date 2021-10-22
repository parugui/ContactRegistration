using ContactsRegistration.Domain.Models.Entities.Validator;
using ContactsRegistration.Domain.Models.Enums;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ContactsRegistration.Domain.Models.Entities
{
	public class NaturalPerson: Entity
	{
		/// <summary>
		/// Name of Person
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Brazilian CPF document. Format: 999.999.999-99
		/// </summary>
		public string CPF { get; private set; }

		/// <summary>
		/// Date of Birthday
		/// </summary>
		public DateTime? Birthday { get; private set; }

		/// <summary>
		/// Gender. Can be male or female
		/// </summary>
		public Gender Gender { get; private set; }

		/// <summary>
		/// Address Zip Code
		/// </summary>
		public string ZipCode { get; private set; }

		/// <summary>
		/// Country
		/// </summary>
		public string Country { get; private set; }

		/// <summary>
		/// State
		/// </summary>
		public string State { get; private set; }

		/// <summary>
		/// City
		/// </summary>
		public string City { get; private set; }

		/// <summary>
		/// Address Line 1
		/// </summary>
		public string AddressLine1 { get; private set; }

		/// <summary>
		/// Address Line 2
		/// </summary>
		public string AddressLine2 { get; private set; }

		/// <summary>
		/// Create a Natural Person instance
		/// </summary>
		/// <param name="name">Name of Person</param>
		/// <param name="cpf">Brazilian CPF document. Format: 999.999.999-99</param>
		/// <param name="birthday">Date of Birthday</param>
		/// <param name="gender">Gender. Can be male or female</param>
		/// <param name="zipCode">Address Zip Code</param>
		/// <param name="country">Country</param>
		/// <param name="state">State</param>
		/// <param name="city">City</param>
		/// <param name="addressLine1">Address Line 1</param>
		/// <param name="addressLine2">Address Line 2</param>
		public NaturalPerson(string name, string cpf, DateTime? birthday, Gender gender, string zipCode, string country, string state, string city, 
						     string addressLine1, string addressLine2)
        {
			Name = name;
			CPF = cpf;
			Birthday = birthday;
			Gender = gender;
			ZipCode = zipCode;
			Country = country;
			State = state;
			City = city;
			AddressLine1 = addressLine1;
			AddressLine2 = addressLine2;
        }

		public override async Task<ValidationResult> IsValidAsync()
			=> await new NaturalPersonValidator().ValidateAsync(this);
	}
}
