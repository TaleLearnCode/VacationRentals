using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{
	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.Content"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void Content(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Content>(entity =>
			{
				entity.ToTable("Content");

				entity.Property(e => e.Id)
					.HasColumnName("ContentId");

				entity.Property(e => e.TypeId)
					.HasColumnName("ContentTypeId");

				entity.HasOne(d => d.ContentType)
					.WithMany(p => p.Contents)
					.HasForeignKey(d => d.TypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkContent_ContentType");
			});
		}

	}

}