using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Cretes the Entity Framework model for <see cref="Entities.CountryDivision"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void CountryDivision(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CountryDivision>(entity =>
			{
				entity.HasKey(e => new { e.CountryDivisionCode, e.CountryCode })
						.HasName("pkcCountryDivision");

				entity.ToTable("CountryDivision");

				entity.Property(e => e.CountryDivisionCode)
						.HasMaxLength(3)
						.IsUnicode(false)
						.IsFixedLength(true);

				entity.Property(e => e.CountryCode)
						.HasMaxLength(2)
						.IsUnicode(false)
						.IsFixedLength(true);

				entity.Property(e => e.CategoryName)
						.IsRequired()
						.HasMaxLength(100)
						.IsUnicode(false);

				entity.Property(e => e.CountryDivisionName)
						.IsRequired()
						.HasMaxLength(100);

				entity.HasOne(d => d.CountryCodeNavigation)
						.WithMany(p => p.CountryDivisions)
						.HasForeignKey(d => d.CountryCode)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkCountryDivision_Country");
			});
		}

	}

}