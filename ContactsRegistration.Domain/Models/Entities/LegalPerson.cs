using ContactsRegistration.Domain.Models.Entities.Validator;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace ContactsRegistration.Domain.Models.Entities
{
    /// <summary>
    /// This class represents ContactLegal Table
    /// </summary>
    public class LegalPerson: Entity
    {
		/// <summary>
		/// Company Name
		/// </summary>
		public string CompanyName { get; private set; }

		/// <summary>
		/// Trade Name
		/// </summary>
		public string TradeName { get; private set; }

		/// <summary>
		/// Company's brazilian CNPJ document. Format: 99.999.999/9999-99
		/// </summary>
		public string CNPJ { get; private set; }

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
		/// Create a Legal Person instance
		/// </summary>
		/// <param name="companyName">Company Name</param>
		/// <param name="tradeName">Trade Name</param>
		/// <param name="cnpj">Company's brazilian CNPJ document. Format: 99.999.999/9999-99</param>
		/// <param name="zipCode">Address Zip Code</param>
		/// <param name="country">Country</param>
		/// <param name="state">State</param>
		/// <param name="city">City</param>
		/// <param name="addressLine1">Address Line 1</param>
		/// <param name="addressLine2">Address Line 2</param>
		public LegalPerson(string companyName, string tradeName, string cnpj, string zipCode, string country, string state, string city,
						  string addressLine1, string addressLine2)
        {
			CompanyName = companyName;
			TradeName = tradeName;
			CNPJ = cnpj;
			ZipCode = zipCode;
			Country = country;
			State = state;
			City = city;
			AddressLine1 = addressLine1;
			AddressLine2 = addressLine2;
		}

		public override async Task<ValidationResult> IsValidAsync()
			=> await new LegalPersonValidator().ValidateAsync(this);
	}
}
