using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PropertyAttribute"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PropertyAttribute(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PropertyAttribute>(entity =>
			{
				entity.HasKey(e => new { e.PropertyId, e.AttributeId })
					.HasName("pkcPropertyAttribute");

				entity.ToTable("PropertyAttribute");

				entity.HasOne(d => d.Attribute)
					.WithMany(p => p.PropertyAttributes)
					.HasForeignKey(d => d.AttributeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPropertyAttribute_Attribute");

				entity.HasOne(d => d.Property)
					.WithMany(p => p.PropertyAttributes)
					.HasForeignKey(d => d.PropertyId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPropertyAttribute_Property");
			});
		}

	}

}