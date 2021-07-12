using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.UserAccountPostalAddress"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void UserAccountPostalAddress(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserAccountPostalAddress>(entity =>
			{
				entity.HasKey(e => new { e.UserAccountId, e.PostalAddressId })
						.HasName("pkcUserAccountPostalAddress");

				entity.ToTable("UserAccountPostalAddress");

				entity.HasOne(d => d.PostalAddress)
						.WithMany(p => p.UserAccountPostalAddresses)
						.HasForeignKey(d => d.PostalAddressId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkUserAccountPostalAddress_PostalAddress");

				entity.HasOne(d => d.UserAccount)
						.WithMany(p => p.UserAccountPostalAddresses)
						.HasForeignKey(d => d.UserAccountId)
						.OnDelete(DeleteBehavior.ClientSetNull)
						.HasConstraintName("fkUserAccountPostalAddress_UserAccount");
			});
		}

	}

}