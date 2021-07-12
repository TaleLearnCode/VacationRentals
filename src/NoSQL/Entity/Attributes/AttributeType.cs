﻿using Newtonsoft.Json;
using System.Collections.Generic;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{
	public class AttributeType
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "attributeTypeId")]
		public string AttributeTypeId { get; set; }

		[JsonProperty(PropertyName = "languageCultureId")]
		public string LanguageCultureId { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "attributeDataType")]
		public ReferenceType AttributeDataType { get; set; }

		[JsonProperty(PropertyName = "attributeCategoryId")]
		public string AttributeCategoryId { get; set; }

		[JsonProperty(PropertyName = "attributeCategory")]
		public ReferenceType AttributeCategory { get; set; }

		[JsonProperty(PropertyName = "label")]
		public ContentCopy Label { get; set; }

		[JsonProperty(PropertyName = "possibleValue")]
		public List<AttributePossibleValue> PossibleValues { get; set; }

		[JsonProperty(PropertyName = "sortOrder")]
		public int SortOrder { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}