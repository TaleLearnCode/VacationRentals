using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class LocalizedAttributeValue
	{

		[JsonProperty(PropertyName = "attributeTypeId")]
		public string AttributeTypeId { get; set; }

		[JsonProperty(PropertyName = "attributeType")]
		public LocalizedAttributeType AttributeType { get; set; }

		[JsonProperty(PropertyName = "lookupValueId")]
		public string LookupValueId { get; set; }

		[JsonProperty(PropertyName = "languageCultureId")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "value")]
		public string Value { get; set; }

	}

}