using ContactsRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ContactsRegistration.Application.ViewModels
{
	[Serializable]
	[DataContract]
	public class vmContact
	{
		[DataMember]
		public int? IdContact { get; set; }
		//Natural Person Fields
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public string CPF { get; set; }
		[DataMember]
		public string Birthday { get; set; }
		[DataMember]
		public int gender { get; set; }

		//Legal Person Fields
		[DataMember]
		public string CompanyName { get; set; }
		[DataMember]
		public string TradeName { get; set; }
		[DataMember]
		public string CNPJ { get; set; }

		//Common Fields
		[DataMember]
		public string ZipCode { get; set; }
		[DataMember]
		public string Country { get; set; }
		[DataMember]
		public string State { get; set; }
		[DataMember]
		public string City { get; set; }
		[DataMember]
		public string AddressLine1 { get; set; }
		[DataMember]
		public string AddressLine2 { get; set; }
	}
}
