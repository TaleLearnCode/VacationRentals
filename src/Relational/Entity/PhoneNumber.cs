using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{

	public class PhoneNumber
	{

		public PhoneNumber()
		{
			UserAccountPhoneNumbers = new HashSet<UserAccountPhoneNumber>();
		}

		public int Id { get; set; }

		public int PhoneNumberTypeId { get; set; }

		public string CountryCode { get; set; }

		public string Number { get; set; }

		public bool IsActive { get; set; }

		public virtual PhoneNumberType PhoneNumberType { get; set; }

		public virtual ICollection<UserAccountPhoneNumber> UserAccountPhoneNumbers { get; set; }

	}

}