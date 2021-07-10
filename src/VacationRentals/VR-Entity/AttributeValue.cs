using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{

	public class AttributeValue
	{

		public AttributeValue()
		{
			PropertyAttributes = new HashSet<PropertyAttribute>();
			RoomAttributes = new HashSet<RoomAttribute>();
		}

		public int AttributeId { get; set; }

		public int AttributeTypeId { get; set; }

		public int? LookupValueId { get; set; }

		public string NumericValue { get; set; }

		public int? AlphaValueId { get; set; }

		public virtual Content AlphaValue { get; set; }

		public virtual AttributeLookupValue LookupValue { get; set; }

		public virtual AttributeType AttributeType { get; set; }

		public virtual ICollection<PropertyAttribute> PropertyAttributes { get; set; }

		public virtual ICollection<RoomAttribute> RoomAttributes { get; set; }

	}

}