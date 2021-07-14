using Newtonsoft.Json;
using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class AttributeValue
	{

		[JsonProperty(PropertyName = "attributeTypeId")]
		public string AttributeTypeId { get; set; }

		[JsonProperty(PropertyName = "attributeType")]
		public ContentCopy AttributeType { get; set; }

		[JsonProperty(PropertyName = "lookupValueId")]
		public string LookupValueId { get; set; }

		[JsonProperty(PropertyName = "value")]
		public ContentCopy Value { get; set; }

	}

}