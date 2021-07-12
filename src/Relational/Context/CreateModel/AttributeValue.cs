using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.AttributeValue"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeValue(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeValue>(entity =>
			{
				entity.HasKey(e => e.AttributeId)
						.HasName("pkcAttribute");

				entity.ToTable("AttributeValue");

				entity.Property(e => e.AttributeNumbericValue)
						.HasMaxLength(20)
						.IsUnicode(false);

				entity.HasOne(d => d.AttributeAlphaValue)
						.WithMany(p => p.AttributeValues)
						.HasForeignKey(d => d.AttributeAlphaValueId)
						.HasConstraintName("fkAttribute_Content");

				entity.HasOne(d => d.AttributeLookupValue)
						.WithMany(p => p.AttributeValues)
						.HasForeignKey(d => d.AttributeLookupValueId)
						.HasConstraintName("fkAttribute_AttributeLookupValue");

				entity.HasOne(d => d.AttributeType)
						.WithMany(p => p.AttributeValues)
						.HasForeignKey(d => d.AttributeTypeId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkAttribute_AttributeType");
			});
		}

	}

}