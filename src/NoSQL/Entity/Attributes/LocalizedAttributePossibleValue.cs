using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class LocalizedAttributePossibleValue
	{

		[JsonProperty(PropertyName = "sortOrder")]
		public int SortOrder { get; set; }

		[JsonProperty(PropertyName = "label")]
		public string Label { get; set; }

	}

}