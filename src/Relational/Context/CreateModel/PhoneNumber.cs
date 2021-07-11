using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PhoneNumber"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PhoneNumber(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhoneNumber>(entity =>
			{
				entity.ToTable("PhoneNumber");

				entity.Property(e => e.Id)
					.HasColumnName("PhoneNumberId");

				entity.Property(e => e.CountryCode)
					.IsRequired()
					.HasMaxLength(3)
					.IsUnicode(false)
					.IsFixedLength();

				entity.Property(e => e.Number)
					.IsRequired()
					.HasMaxLength(20)
					.IsUnicode(false)
					.HasColumnName("PhoneNumber");

				entity.HasOne(d => d.PhoneNumberType)
					.WithMany(p => p.PhoneNumbers)
					.HasForeignKey(d => d.PhoneNumberTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkPhoneNumber_PhoneNumberType");
			});
		}

	}

}