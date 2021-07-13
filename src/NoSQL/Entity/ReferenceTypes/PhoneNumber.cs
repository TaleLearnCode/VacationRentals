using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class PhoneNumber
	{

		[JsonProperty(PropertyName = "phoneNumberTypeId")]
		public string PhoneNumberTypeId { get; set; }

		[JsonProperty(PropertyName = "phoneNumberType")]
		public string PhoneNumberType { get; set; }

		[JsonProperty(PropertyName = "countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "number")]
		public string Number { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}