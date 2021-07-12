using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class AttributeValue
	{

		[JsonProperty(PropertyName = "attributeTypeId")]
		public string AttributeTypeId { get; set; }

		[JsonProperty(PropertyName = "attributeType")]
		public AttributeType AttributeType { get; set; }

		[JsonProperty(PropertyName = "lookupValueId")]
		public string LookupValueId { get; set; }

		[JsonProperty(PropertyName = "value")]
		public List<ContentCopy> Value { get; set; }

	}

}