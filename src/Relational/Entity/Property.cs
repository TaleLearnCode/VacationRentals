using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class Property
	{

		public Property()
		{
			PropertyAttributes = new HashSet<PropertyAttribute>();
			RentalRates = new HashSet<RentalRate>();
			Rooms = new HashSet<Room>();
		}

		public int Id { get; set; }

		public int UserAccountId { get; set; }

		public int PropertyNameId { get; set; }

		public int HeadlineId { get; set; }

		public int? SummaryId { get; set; }

		public int DescriptionId { get; set; }

		public int PropertyTypeId { get; set; }

		public int PostalAddressId { get; set; }

		public virtual Content Description { get; set; }

		public virtual Content Headline { get; set; }

		public virtual PostalAddress PostalAddress { get; set; }

		public virtual Content PropertyName { get; set; }

		public virtual PropertyType PropertyType { get; set; }

		public virtual Content Summary { get; set; }

		public virtual UserAccount UserAccount { get; set; }

		public virtual ICollection<PropertyAttribute> PropertyAttributes { get; set; }

		public virtual ICollection<RentalRate> RentalRates { get; set; }

		public virtual ICollection<Room> Rooms { get; set; }

	}
}