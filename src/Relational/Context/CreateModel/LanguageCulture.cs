using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.LanguageCulture"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void LanguageCulture(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<LanguageCulture>(entity =>
			{
				entity.ToTable("LanguageCulture");

				entity.Property(e => e.Id)
					.HasColumnName("LanguageCultureId")
					.HasMaxLength(15)
					.IsUnicode(false);

				entity.Property(e => e.EnglishName)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.LanguageCode)
					.IsRequired()
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.NativeName)
					.IsRequired()
					.HasMaxLength(100);
			});
		}

	}

}