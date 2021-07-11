using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.ContentType"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void ContentType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContentType>(entity =>
			{
				entity.ToTable("ContentType");

				entity.Property(e => e.Id)
					.HasColumnName("ContentTypeId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("ContentTypeName")
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);
			});
		}

	}

}