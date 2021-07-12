using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class LocalizedReferenceType
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "referenceTypeName")]
		public string ReferenceTypeName { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

	}

}