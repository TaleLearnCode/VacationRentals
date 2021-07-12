using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class PhoneNumberType
	{
		public PhoneNumberType()
		{
			PhoneNumbers = new HashSet<PhoneNumber>();
		}

		public int PhoneNumberTypeId { get; set; }
		public string PhoneNumberTypeName { get; set; }
		public int SortOrder { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
	}
}