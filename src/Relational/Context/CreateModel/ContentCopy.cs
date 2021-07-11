using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.ContentCopy"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void ContentCopy(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContentCopy>(entity =>
			{
				entity.HasKey(e => new { e.ContentId, e.LanguageCultureId })
					.HasName("pkcContentCopy");

				entity.ToTable("ContentCopy");

				entity.Property(e => e.LanguageCultureId)
					.HasMaxLength(15)
					.IsUnicode(false);

				entity.Property(e => e.CopyText).IsRequired();

				entity.HasOne(d => d.Content)
					.WithMany(p => p.ContentCopies)
					.HasForeignKey(d => d.ContentId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkContentCopy_Content");

				entity.HasOne(d => d.LanguageCulture)
					.WithMany(p => p.ContentCopies)
					.HasForeignKey(d => d.LanguageCultureId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkContentCopy_LanguageCultureId");
			});

		}

	}

}