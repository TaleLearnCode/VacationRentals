using System;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class RentalRate
	{
		public int RentalRateId { get; set; }
		public int PropertyId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal Rate { get; set; }

		public virtual Property Property { get; set; }
	}
}