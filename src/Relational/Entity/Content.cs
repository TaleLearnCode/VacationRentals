using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class Content
	{

		public Content()
		{
			AttributeLookupValues = new HashSet<AttributeLookupValue>();
			AttributeTypes = new HashSet<AttributeType>();
			AttributeValues = new HashSet<AttributeValue>();
			ContentCopies = new HashSet<ContentCopy>();
			PropertyDescriptions = new HashSet<Property>();
			PropertyHeadlines = new HashSet<Property>();
			PropertyNames = new HashSet<Property>();
			PropertySummaries = new HashSet<Property>();
			PropertyTypes = new HashSet<PropertyType>();
			RoomNames = new HashSet<Room>();
		}

		public int Id { get; set; }

		public int TypeId { get; set; }

		public bool IsActive { get; set; }

		public virtual ContentType ContentType { get; set; }

		public virtual ICollection<AttributeLookupValue> AttributeLookupValues { get; set; }

		public virtual ICollection<AttributeType> AttributeTypes { get; set; }

		public virtual ICollection<AttributeValue> AttributeValues { get; set; }

		public virtual ICollection<ContentCopy> ContentCopies { get; set; }

		public virtual ICollection<Property> PropertyDescriptions { get; set; }

		public virtual ICollection<Property> PropertyHeadlines { get; set; }

		public virtual ICollection<Property> PropertyNames { get; set; }

		public virtual ICollection<Property> PropertySummaries { get; set; }

		public virtual ICollection<PropertyType> PropertyTypes { get; set; }

		public virtual ICollection<Room> RoomDescriptions { get; set; }

		public virtual ICollection<Room> RoomNames { get; set; }

	}
}