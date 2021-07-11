using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class CountryDivision
	{

		public CountryDivision()
		{
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public string Code { get; set; }

		public string CountryCode { get; set; }

		public string Name { get; set; }

		public string Category { get; set; }

		public bool IsActive { get; set; }

		public virtual Country Country { get; set; }

		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }

	}
}