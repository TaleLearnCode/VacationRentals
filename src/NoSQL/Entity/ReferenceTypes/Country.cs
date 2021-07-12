using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class Country
	{

		[JsonProperty(PropertyName = "id")]
		public string Code { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "divisionName")]
		public string DivisionName { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}