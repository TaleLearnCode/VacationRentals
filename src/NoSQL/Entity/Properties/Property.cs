using Newtonsoft.Json;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class Property
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "languageCultureId")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "name")]
		public ContentCopy Name { get; set; }

		[JsonProperty(PropertyName = "headline")]
		public ContentCopy Headline { get; set; }

		[JsonProperty(PropertyName = "summary")]
		public ContentCopy Summary { get; set; }

		[JsonProperty(PropertyName = "description")]
		public ContentCopy Description { get; set; }

		[JsonProperty(PropertyName = "propertyTypeId")]
		public string PropertyTypeId { get; set; }

		[JsonProperty(PropertyName = "propertyType")]
		public ContentCopy PropertyType { get; set; }

		[JsonProperty(PropertyName = "address")]
		public PostalAddress Address { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}