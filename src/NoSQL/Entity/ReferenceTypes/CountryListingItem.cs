using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class CountryListingItem
	{

		[JsonProperty(PropertyName = "code")]
		public string Code { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "category")]
		public string Category { get; set; }

	}

}