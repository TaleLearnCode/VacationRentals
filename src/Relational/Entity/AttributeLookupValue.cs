using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class AttributeLookupValue
	{

		public AttributeLookupValue()
		{
			AttributeValues = new HashSet<AttributeValue>();
		}

		public int Id { get; set; }

		public int AttributeTypeId { get; set; }

		public int PossibleValueId { get; set; }

		public int SortOrder { get; set; }

		public bool IsActive { get; set; }

		public virtual AttributeType AttributeType { get; set; }

		public virtual Content PossibleValue { get; set; }

		public virtual ICollection<AttributeValue> AttributeValues { get; set; }

	}

}