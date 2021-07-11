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
				entity.HasKey(e => e.Id)
					.HasName("pkcAttribute");

				entity.ToTable("AttributeValue");

				entity.Property(e => e.Id)
					.HasColumnName("AttributeId");

				entity.Property(e => e.LookupValueId)
					.HasColumnName("AttributeLookupValueId");

				entity.Property(e => e.NumericValue)
					.HasColumnName("AttributeNumbericValue")
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.AlphaValueId)
					.HasColumnName("AttributeAlphaValueId");

				entity.HasOne(d => d.AlphaValue)
					.WithMany(p => p.AttributeValues)
					.HasForeignKey(d => d.AlphaValueId)
					.HasConstraintName("fkAttribute_Content");

				entity.HasOne(d => d.LookupValue)
					.WithMany(p => p.AttributeValues)
					.HasForeignKey(d => d.LookupValueId)
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