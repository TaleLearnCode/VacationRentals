using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class AttributeLookupValue
	{
		public AttributeLookupValue()
		{
			AttributeValues = new HashSet<AttributeValue>();
		}

		public int AttributeLookupValueId { get; set; }
		public string AttributeLookupValueName { get; set; }
		public int AttributeTypeId { get; set; }
		public int PossibleValueId { get; set; }
		public int SortOrder { get; set; }
		public bool IsActive { get; set; }

		public virtual AttributeType AttributeType { get; set; }
		public virtual Content PossibleValue { get; set; }
		public virtual ICollection<AttributeValue> AttributeValues { get; set; }
	}

}