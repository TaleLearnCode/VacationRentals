namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class UserAccountPostalAddress
	{
		public int UserAccountId { get; set; }
		public int PostalAddressId { get; set; }

		public virtual PostalAddress PostalAddress { get; set; }
		public virtual UserAccount UserAccount { get; set; }
	}

}