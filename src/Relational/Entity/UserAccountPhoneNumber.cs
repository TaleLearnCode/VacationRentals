namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class UserAccountPhoneNumber
	{
		public int UserAccountId { get; set; }
		public int PhoneNumberId { get; set; }

		public virtual PhoneNumber PhoneNumber { get; set; }
		public virtual UserAccount UserAccount { get; set; }
	}
}