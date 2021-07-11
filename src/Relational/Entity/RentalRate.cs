using System;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public class RentalRate
	{

		public int Id { get; set; }

		public int PropertyId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public decimal Rate { get; set; }

		public virtual Property Property { get; set; }

	}
}