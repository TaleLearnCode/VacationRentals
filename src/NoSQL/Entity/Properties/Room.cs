using Newtonsoft.Json;
using TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class Room
	{

		[JsonProperty(PropertyName = "id")]
		public string RoomTypeId { get; set; }

		[JsonProperty(PropertyName = "roomType")]
		public ContentCopy RoomType { get; set; }

		[JsonProperty(PropertyName = "name")]
		public ContentCopy Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public ContentCopy Description { get; set; }

		[JsonProperty(PropertyName = "attributes")]
		public AttributeValueListing Attributes { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}