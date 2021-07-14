using Newtonsoft.Json;
using System.Collections.Generic;
using TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class Room
	{

		[JsonProperty(PropertyName = "roomTypeId")]
		public string RoomTypeId { get; set; }

		[JsonProperty(PropertyName = "roomType")]
		public ContentCopy RoomType { get; set; }

		[JsonProperty(PropertyName = "name")]
		public ContentCopy Name { get; set; }

		[JsonProperty(PropertyName = "description")]
		public ContentCopy Description { get; set; }

		[JsonProperty(PropertyName = "attributes")]
		public List<AttributeValue> Attributes { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}