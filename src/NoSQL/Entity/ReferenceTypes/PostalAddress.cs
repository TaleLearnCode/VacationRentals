using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{
	public class PostalAddress
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "postalAddressTypeId")]
		public string PostalAddressTypeId { get; set; }

		[JsonProperty(PropertyName = "postalAddressType")]
		public string PostalAddressType { get; set; }

		[JsonProperty(PropertyName = "streetAddress1")]
		public string StreetAddress1 { get; set; }

		[JsonProperty(PropertyName = "streetAddress2")]
		public string StreetAddress2 { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string City { get; set; }

		[JsonProperty(PropertyName = "countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[JsonProperty(PropertyName = "countryDivisionCode")]
		public string CountryDivisionCode { get; set; }

		[JsonProperty(PropertyName = "countryDivision")]
		public string CountryDivision { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}