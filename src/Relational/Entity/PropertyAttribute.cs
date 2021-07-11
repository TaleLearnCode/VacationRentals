namespace TaleLearnCode.VacationRentals.Entities
{
	public class PropertyAttribute
	{

		public int PropertyId { get; set; }

		public int AttributeId { get; set; }

		public virtual AttributeValue Attribute { get; set; }

		public virtual Property Property { get; set; }

	}
}