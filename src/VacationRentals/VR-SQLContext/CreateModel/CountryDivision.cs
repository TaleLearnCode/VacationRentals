using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
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
				entity.HasKey(e => new { e.Code, e.CountryCode })
					.HasName("pkcCountryDivision");

				entity.ToTable("CountryDivision");

				entity.Property(e => e.Code)
					.HasColumnName("CountryDivisionCode")
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.CountryCode)
					.HasMaxLength(2)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.Category)
					.HasColumnName("CategoryName")
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);

				entity.Property(e => e.Name)
					.HasColumnName("CountryDivisionName")
					.IsRequired()
					.HasMaxLength(100);

				entity.HasOne(d => d.Country)
					.WithMany(p => p.CountryDivisions)
					.HasForeignKey(d => d.CountryCode)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkCountryDivision_Country");
			});
		}

	}

}