using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class CountryDivision
	{
		public CountryDivision()
		{
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public string CountryDivisionCode { get; set; }
		public string CountryCode { get; set; }
		public string CountryDivisionName { get; set; }
		public string CategoryName { get; set; }
		public bool IsActive { get; set; }

		public virtual Country CountryCodeNavigation { get; set; }
		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }
	}
}