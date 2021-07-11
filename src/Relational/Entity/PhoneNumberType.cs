using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class PhoneNumberType
	{

		public PhoneNumberType()
		{
			PhoneNumbers = new HashSet<PhoneNumber>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int SortOrder { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

	}
}