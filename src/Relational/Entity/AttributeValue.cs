using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public partial class AttributeValue
	{
		public AttributeValue()
		{
			PropertyAttributes = new HashSet<PropertyAttribute>();
			RoomAttributes = new HashSet<RoomAttribute>();
		}

		public int AttributeId { get; set; }
		public int AttributeTypeId { get; set; }
		public int? AttributeLookupValueId { get; set; }
		public string AttributeNumbericValue { get; set; }
		public int? AttributeAlphaValueId { get; set; }

		public virtual Content AttributeAlphaValue { get; set; }
		public virtual AttributeLookupValue AttributeLookupValue { get; set; }
		public virtual AttributeType AttributeType { get; set; }
		public virtual ICollection<PropertyAttribute> PropertyAttributes { get; set; }
		public virtual ICollection<RoomAttribute> RoomAttributes { get; set; }
	}

}