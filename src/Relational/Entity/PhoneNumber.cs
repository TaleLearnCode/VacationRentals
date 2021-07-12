using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public partial class PhoneNumber
	{
		public PhoneNumber()
		{
			UserAccountPhoneNumbers = new HashSet<UserAccountPhoneNumber>();
		}

		public int PhoneNumberId { get; set; }
		public int PhoneNumberTypeId { get; set; }
		public string CountryCode { get; set; }
		public string PhoneNumber1 { get; set; }
		public bool IsActive { get; set; }

		public virtual PhoneNumberType PhoneNumberType { get; set; }
		public virtual ICollection<UserAccountPhoneNumber> UserAccountPhoneNumbers { get; set; }
	}

}