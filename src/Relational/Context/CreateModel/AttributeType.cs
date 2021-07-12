using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.AttributeType"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeType>(entity =>
			{
				entity.ToTable("AttributeType");

				entity.Property(e => e.AttributeTypeId).ValueGeneratedNever();

				entity.Property(e => e.AttributeTypeName)
						.IsRequired()
						.HasMaxLength(100);

				entity.HasOne(d => d.AttributeCategory)
						.WithMany(p => p.AttributeTypes)
						.HasForeignKey(d => d.AttributeCategoryId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkAttributeType_AttributeCategory");

				entity.HasOne(d => d.AttributeDataType)
						.WithMany(p => p.AttributeTypes)
						.HasForeignKey(d => d.AttributeDataTypeId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkAttributeType_AttributeDataType");

				entity.HasOne(d => d.Label)
						.WithMany(p => p.AttributeTypes)
						.HasForeignKey(d => d.LabelId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkAttributeType_Content_Label");
			});
		}

	}

}