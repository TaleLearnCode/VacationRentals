using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{

	public class AttributeCategory
	{

		public AttributeCategory()
		{
			AttributeTypes = new HashSet<AttributeType>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<AttributeType> AttributeTypes { get; set; }

	}

}