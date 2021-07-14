using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class AttributePossibleValue
	{

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "sortOrder")]
		public int SortOrder { get; set; }

		[JsonProperty(PropertyName = "label")]
		public ContentCopy Label { get; set; }

	}

}