using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.Country"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void Country(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>(entity =>
			{
				entity.HasKey(e => e.CountryCode)
						.HasName("pkcCountry");

				entity.ToTable("Country");

				entity.Property(e => e.CountryCode)
						.HasMaxLength(2)
						.IsUnicode(false)
						.IsFixedLength(true);

				entity.Property(e => e.CountryName)
						.IsRequired()
						.HasMaxLength(100)
						.IsUnicode(false);

				entity.Property(e => e.DivisionName)
						.HasMaxLength(100)
						.IsUnicode(false);
			});
		}

	}

}