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
				entity.HasKey(e => e.Code)
					.HasName("pkcCountry");

				entity.ToTable("Country");

				entity.Property(e => e.Code)
					.HasColumnName("CountryCode")
					.HasMaxLength(2)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.Name)
					.HasColumnName("CountryName")
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