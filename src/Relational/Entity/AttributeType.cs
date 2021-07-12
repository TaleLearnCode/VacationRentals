using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public partial class AttributeType
	{
		public AttributeType()
		{
			AttributeLookupValues = new HashSet<AttributeLookupValue>();
			AttributeValues = new HashSet<AttributeValue>();
		}

		public int AttributeTypeId { get; set; }
		public string AttributeTypeName { get; set; }
		public int AttributeDataTypeId { get; set; }
		public int AttributeCategoryId { get; set; }
		public int LabelId { get; set; }
		public bool HasDescription { get; set; }
		public int SortOrder { get; set; }
		public bool IsActive { get; set; }

		public virtual AttributeCategory AttributeCategory { get; set; }
		public virtual AttributeDataType AttributeDataType { get; set; }
		public virtual Content Label { get; set; }
		public virtual ICollection<AttributeLookupValue> AttributeLookupValues { get; set; }
		public virtual ICollection<AttributeValue> AttributeValues { get; set; }
	}

}