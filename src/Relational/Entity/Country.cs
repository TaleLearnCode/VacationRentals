using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public partial class Country
	{
		public Country()
		{
			CountryDivisions = new HashSet<CountryDivision>();
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public string CountryCode { get; set; }
		public string CountryName { get; set; }
		public bool HasDivisions { get; set; }
		public string DivisionName { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<CountryDivision> CountryDivisions { get; set; }
		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }
	}

}