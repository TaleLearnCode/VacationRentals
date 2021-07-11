using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public class AttributeType
	{

		public AttributeType()
		{
			AttributeLookupValues = new HashSet<AttributeLookupValue>();
			AttributeValues = new HashSet<AttributeValue>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int DataTypeId { get; set; }

		public int CategoryId { get; set; }

		public int LabelId { get; set; }

		public int SortOrder { get; set; }

		public bool IsActive { get; set; }

		public virtual AttributeCategory AttributeCategory { get; set; }

		public virtual AttributeDataType AttributeDataType { get; set; }

		public virtual Content Label { get; set; }

		public virtual ICollection<AttributeLookupValue> AttributeLookupValues { get; set; }

		public virtual ICollection<AttributeValue> AttributeValues { get; set; }

	}

}