using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PostalAddress"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PostalAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostalAddress>(entity =>
			{
				entity.ToTable("PostalAddress");

				entity.Property(e => e.Id)
					.HasColumnName("PostalAddressId");

				entity.Property(e => e.City)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.CountryCode)
					.IsRequired()
					.HasMaxLength(2)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.CountryDivisionCode)
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.IsActive)
					.IsRequired()
					.HasDefaultValueSql("((1))");

				entity.Property(e => e.PostalCode)
					.HasMaxLength(20)
					.IsUnicode(false);

				entity.Property(e => e.StreetAddress1).HasMaxLength(100);

				entity.Property(e => e.StreetAddress2).HasMaxLength(100);

				entity.HasOne(d => d.Country)
					.WithMany(p => p.PostalAddresses)
					.HasForeignKey(d => d.CountryCode)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPostalAddress_Country");

				entity.HasOne(d => d.PostalAddressType)
					.WithMany(p => p.PostalAddresses)
					.HasForeignKey(d => d.PhoneNumberTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPostalAddress_PostalAddressType");

				entity.HasOne(d => d.Country)
					.WithMany(p => p.PostalAddresses)
					.HasForeignKey(d => new { d.CountryDivisionCode, d.CountryCode })
					.HasConstraintName("fkPostalAddress_CountryDivision");
			});
		}

	}

}