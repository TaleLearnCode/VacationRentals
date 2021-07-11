using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.AttributeLookupValue"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeLookupValue(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeLookupValue>(entity =>
			{
				entity.ToTable("AttributeLookupValue");

				entity.Property(e => e.Id)
					.HasColumnName("AttributeLookupValueId")
					.ValueGeneratedNever();

				entity.HasOne(d => d.AttributeType)
					.WithMany(p => p.AttributeLookupValues)
					.HasForeignKey(d => d.AttributeTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkAttributeLookupValue_AttributeType");

				entity.HasOne(d => d.PossibleValue)
					.WithMany(p => p.AttributeLookupValues)
					.HasForeignKey(d => d.PossibleValueId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkAttributeLookupValue_Content");
			});
		}

	}

}