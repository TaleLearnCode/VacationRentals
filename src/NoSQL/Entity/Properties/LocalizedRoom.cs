using Newtonsoft.Json;
using TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class LocalizedRoom
	{

		[JsonProperty(PropertyName = "id")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "roomType")]
		public string RoomType { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "attriubtes")]
		public LocalizedAttributeValueListing Attributes { get; set; }

	}

}