using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{

	public class UserAccount
	{

		public UserAccount()
		{
			Properties = new HashSet<Property>();
			UserAccountPhoneNumbers = new HashSet<UserAccountPhoneNumber>();
			UserAccountPostalAddresses = new HashSet<UserAccountPostalAddress>();
		}

		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public bool IsPropertyManager { get; set; }

		public virtual ICollection<Property> Properties { get; set; }

		public virtual ICollection<UserAccountPhoneNumber> UserAccountPhoneNumbers { get; set; }

		public virtual ICollection<UserAccountPostalAddress> UserAccountPostalAddresses { get; set; }

	}

}