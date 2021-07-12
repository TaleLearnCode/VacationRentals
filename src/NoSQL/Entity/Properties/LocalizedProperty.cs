using Newtonsoft.Json;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class LocalizedProperty
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "languageCultureId")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "headline")]
		public string Headline { get; set; }

		[JsonProperty(PropertyName = "summary")]
		public string Summary { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "propertyType")]
		public string PropertyType { get; set; }

		[JsonProperty(PropertyName = "address")]
		public PostalAddress Address { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}