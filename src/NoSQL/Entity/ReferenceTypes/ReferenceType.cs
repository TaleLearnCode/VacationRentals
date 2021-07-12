using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class ReferenceType
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "referenceTypeName")]
		public string ReferenceTypeName { get; set; }

		[JsonProperty(PropertyName = "systemName")]
		public string SystemName { get; set; }

		[JsonProperty(PropertyName = "name")]
		public ContentCopy Name { get; set; }

		[JsonProperty(PropertyName = "sortOrder")]
		public int? SortOrder { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}