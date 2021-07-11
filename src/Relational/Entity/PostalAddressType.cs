using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class PostalAddressType
	{

		public PostalAddressType()
		{
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public int SortOrder { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }
	}
}