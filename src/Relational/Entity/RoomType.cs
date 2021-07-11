using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class RoomType
	{

		public RoomType()
		{
			Rooms = new HashSet<Room>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public bool CanHaveMultiple { get; set; }

		public bool IsActive { get; set; }

		public int SortOrder { get; set; }

		public virtual ICollection<Room> Rooms { get; set; }

	}
}