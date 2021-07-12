using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public partial class AttributeCategory
	{
		public AttributeCategory()
		{
			AttributeTypes = new HashSet<AttributeType>();
		}

		public int AttributeCategoryId { get; set; }
		public string AttributeCategoryName { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<AttributeType> AttributeTypes { get; set; }
	}

}