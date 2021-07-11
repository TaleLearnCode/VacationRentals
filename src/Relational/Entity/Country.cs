using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{

	public class Country
	{

		public Country()
		{
			CountryDivisions = new HashSet<CountryDivision>();
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public string Code { get; set; }

		public string Name { get; set; }

		public bool HasDivisions { get; set; }

		public string DivisionName { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<CountryDivision> CountryDivisions { get; set; }

		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }

	}

}