using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class Room
	{

		public Room()
		{
			RoomAttributes = new HashSet<RoomAttribute>();
		}

		public int Id { get; set; }

		public int PropertyId { get; set; }

		public int RoomTypeId { get; set; }

		public int RoomNameId { get; set; }

		public int DescriptionId { get; set; }

		public bool? IsActive { get; set; }

		public virtual Content Description { get; set; }

		public virtual Property Property { get; set; }

		public virtual Content RoomName { get; set; }

		public virtual RoomType RoomType { get; set; }

		public virtual ICollection<RoomAttribute> RoomAttributes { get; set; }

	}
}