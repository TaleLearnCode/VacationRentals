using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class RoomType
	{
		public RoomType()
		{
			Rooms = new HashSet<Room>();
		}

		public int RoomTypeId { get; set; }
		public string RoomTypeName { get; set; }
		public bool CanHaveMultiple { get; set; }
		public bool IsActive { get; set; }
		public int SortOrder { get; set; }

		public virtual ICollection<Room> Rooms { get; set; }
	}
}