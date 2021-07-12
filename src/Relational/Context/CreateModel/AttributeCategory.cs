using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.AttributeCategory"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeCategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeCategory>(entity =>
			{
				entity.ToTable("AttributeCategory");

				entity.Property(e => e.AttributeCategoryId).ValueGeneratedNever();

				entity.Property(e => e.AttributeCategoryName)
						.IsRequired()
						.HasMaxLength(100);
			});
		}

	}

}