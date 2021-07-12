using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class RentalRateByCountryListing : RentalRate
	{

		[JsonProperty(PropertyName = "countryCode")]
		public string CountryCode { get; set; }

	}

}