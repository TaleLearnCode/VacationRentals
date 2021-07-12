﻿using Newtonsoft.Json;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Properties
{

	public class PropertyByCountryListing
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "countryCode")]
		public string CountryCode { get; set; }

		[JsonProperty(PropertyName = "name")]
		public ContentCopy Name { get; set; }

		[JsonProperty(PropertyName = "propertyTypeId")]
		public string PropertyTypeId { get; set; }

		[JsonProperty(PropertyName = "propertyType")]
		public ReferenceType PropertyType { get; set; }

	}

}