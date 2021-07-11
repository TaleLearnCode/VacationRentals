using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.UserAccountPhoneNumber"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void UserAccountPhoneNumber(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserAccountPhoneNumber>(entity =>
			{
				entity.HasKey(e => new { e.UserAccountId, e.PhoneNumberId })
					.HasName("pkcUserAccountPhoneNumber");

				entity.ToTable("UserAccountPhoneNumber");

				entity.HasOne(d => d.PhoneNumber)
					.WithMany(p => p.UserAccountPhoneNumbers)
					.HasForeignKey(d => d.PhoneNumberId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkUserAccountPhoneNumber_PhoneNumber");

				entity.HasOne(d => d.UserAccount)
					.WithMany(p => p.UserAccountPhoneNumbers)
					.HasForeignKey(d => d.UserAccountId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkUserAccountPhoneNumber_UserAccount");
			});
		}

	}

}