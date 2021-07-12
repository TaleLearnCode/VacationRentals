using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class ContentType
	{
		public ContentType()
		{
			Contents = new HashSet<Content>();
		}

		public int ContentTypeId { get; set; }
		public string ContentTypeName { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<Content> Contents { get; set; }
	}
}