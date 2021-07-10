using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class ContentType
	{

		public ContentType()
		{
			Contents = new HashSet<Content>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<Content> Contents { get; set; }
	}
}