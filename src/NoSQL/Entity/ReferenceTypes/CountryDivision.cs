using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{
	public class CountryDivision : CountryListingItem
	{

		[JsonProperty(PropertyName = "referenceTypeName")]
		public string ReferenceTypeName => "CountryDivision";

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

		public CountryDivision() { }

		public CountryDivision(string countryCode, string countryDivisionCode)
		{
			Id = $"{countryCode}-{countryDivisionCode}";
			Code = countryDivisionCode;
			CountryCode = countryCode;
		}

	}
}
