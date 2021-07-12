using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{
	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.Property"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void Property(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Property>(entity =>
			{
				entity.ToTable("Property");

				entity.HasOne(d => d.Description)
						.WithMany(p => p.PropertyDescriptions)
						.HasForeignKey(d => d.DescriptionId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_Content_Description");

				entity.HasOne(d => d.Headline)
						.WithMany(p => p.PropertyHeadlines)
						.HasForeignKey(d => d.HeadlineId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_Content_Headline");

				entity.HasOne(d => d.PostalAddress)
						.WithMany(p => p.Properties)
						.HasForeignKey(d => d.PostalAddressId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_PostalAddressId");

				entity.HasOne(d => d.PropertyName)
						.WithMany(p => p.PropertyPropertyNames)
						.HasForeignKey(d => d.PropertyNameId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_Content_PropertyName");

				entity.HasOne(d => d.PropertyType)
						.WithMany(p => p.Properties)
						.HasForeignKey(d => d.PropertyTypeId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_PropertyType");

				entity.HasOne(d => d.Summary)
						.WithMany(p => p.PropertySummaries)
						.HasForeignKey(d => d.SummaryId)
						.HasConstraintName("fkProperty_Content_Summary");

				entity.HasOne(d => d.UserAccount)
						.WithMany(p => p.Properties)
						.HasForeignKey(d => d.UserAccountId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkProperty_UserAccount");
			});
		}

	}

}