using Newtonsoft.Json;
using System;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class RentalRate
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; } = Guid.NewGuid().ToString();

		[JsonProperty(PropertyName = "propertyId")]
		public string PropertyId { get; set; }

		[JsonProperty(PropertyName = "startDate")]
		public DateTime StartDate { get; set; }

		[JsonProperty(PropertyName = "endDate")]
		public DateTime EndDate { get; set; }

		[JsonProperty(PropertyName = "rate")]
		public decimal Rate { get; set; }

	}

}