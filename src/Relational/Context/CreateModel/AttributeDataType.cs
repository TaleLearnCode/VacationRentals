using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framwork model for <see cref="Entities.AttributeDataType"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeDataType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeDataType>(entity =>
			{
				entity.ToTable("AttributeDataType");

				entity.Property(e => e.AttributeDataTypeId).ValueGeneratedNever();

				entity.Property(e => e.AttributeDataTypeName)
						.IsRequired()
						.HasMaxLength(100);
			});
		}

	}

}