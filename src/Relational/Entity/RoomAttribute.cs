namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class RoomAttribute
	{
		public int RoomId { get; set; }
		public int AttributeId { get; set; }

		public virtual AttributeValue Attribute { get; set; }
		public virtual Room Room { get; set; }
	}

}