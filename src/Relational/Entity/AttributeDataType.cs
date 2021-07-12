using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class AttributeDataType
	{
		public AttributeDataType()
		{
			AttributeTypes = new HashSet<AttributeType>();
		}

		public int AttributeDataTypeId { get; set; }
		public string AttributeDataTypeName { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<AttributeType> AttributeTypes { get; set; }
	}

}