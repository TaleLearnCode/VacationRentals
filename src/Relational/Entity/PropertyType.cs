using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class PropertyType
	{

		public PropertyType()
		{
			Properties = new HashSet<Property>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int LabelId { get; set; }

		public bool IsActive { get; set; }

		public virtual Content Label { get; set; }

		public virtual ICollection<Property> Properties { get; set; }
	}
}