using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class PostalAddress
	{

		public PostalAddress()
		{
			Properties = new HashSet<Property>();
			UserAccountPostalAddresses = new HashSet<UserAccountPostalAddress>();
		}

		public int Id { get; set; }

		public int PhoneNumberTypeId { get; set; }

		public string StreetAddress1 { get; set; }

		public string StreetAddress2 { get; set; }

		public string City { get; set; }

		public string CountryDivisionCode { get; set; }

		public string CountryCode { get; set; }

		public string PostalCode { get; set; }

		public bool? IsActive { get; set; }

		public virtual CountryDivision CountryDivision { get; set; }

		public virtual Country Country { get; set; }

		public virtual PostalAddressType PostalAddressType { get; set; }

		public virtual ICollection<Property> Properties { get; set; }

		public virtual ICollection<UserAccountPostalAddress> UserAccountPostalAddresses { get; set; }

	}
}