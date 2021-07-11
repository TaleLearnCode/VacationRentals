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

				entity.Property(e => e.Id)
					.HasColumnName("AttributeTypeId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("AttributeTypeName")
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.DataTypeId)
					.HasColumnName("AttributeDataTypeId");

				entity.Property(e => e.CategoryId)
					.HasColumnName("AttributeCategoryId");

				entity.HasOne(d => d.AttributeCategory)
					.WithMany(p => p.AttributeTypes)
					.HasForeignKey(d => d.Id)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkAttributeType_AttributeCategory");

				entity.HasOne(d => d.AttributeDataType)
					.WithMany(p => p.AttributeTypes)
					.HasForeignKey(d => d.Id)
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