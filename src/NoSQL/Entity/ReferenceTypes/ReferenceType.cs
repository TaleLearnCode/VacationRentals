using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class ReferenceType
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "referenceTypeName")]
		public string ReferenceTypeName { get; set; }

		[JsonProperty(PropertyName = "name")]
		public List<ContentCopy> Name { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}