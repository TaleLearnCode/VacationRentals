using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class PostalAddressType
	{
		public PostalAddressType()
		{
			PostalAddresses = new HashSet<PostalAddress>();
		}

		public int PostalAddressTypeId { get; set; }
		public string PostalAddressTypeName { get; set; }
		public int SortOrder { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<PostalAddress> PostalAddresses { get; set; }
	}
}