using Newtonsoft.Json;
using System.Collections.Generic;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{
	public class LocalizedAttributeType
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "attributeTypeId")]
		public string AttributeTypeId { get; set; }

		[JsonProperty(PropertyName = "languageCultureId")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "attributeCategoryId")]
		public string AttributeCategoryId { get; set; }

		[JsonProperty(PropertyName = "attributeCategory")]
		public LocalizedReferenceType AttributeCategory { get; set; }

		[JsonProperty(PropertyName = "label")]
		public string Label { get; set; }

		[JsonProperty(PropertyName = "possibleValues")]
		public List<LocalizedAttributePossibleValue> PossibleValues { get; set; }

		[JsonProperty(PropertyName = "sortOrder")]
		public int SortOrder { get; set; }

	}

}