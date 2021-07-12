using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{
	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.RoomType"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void RoomType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RoomType>(entity =>
			{
				entity.ToTable("RoomType");

				entity.Property(e => e.RoomTypeId).ValueGeneratedNever();

				entity.Property(e => e.RoomTypeName)
						.IsRequired()
						.HasMaxLength(100)
						.IsUnicode(false);
			});
		}

	}

}