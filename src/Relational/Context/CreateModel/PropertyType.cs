using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PropertyType"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PropertyType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PropertyType>(entity =>
			{
				entity.ToTable("PropertyType");

				entity.Property(e => e.Id)
					.HasColumnName("PropertyTypeId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("PropertyTypeName")
					.IsRequired()
					.HasMaxLength(100);

				entity.HasOne(d => d.Label)
					.WithMany(p => p.PropertyTypes)
					.HasForeignKey(d => d.LabelId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPropertyType_Content_Label");
			});

		}

	}

}