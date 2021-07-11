using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{
	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.UserAccount"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void UserAccount(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserAccount>(entity =>
			{
				entity.ToTable("UserAccount");

				entity.Property(e => e.Id)
					.HasColumnName("UserAccountId");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasMaxLength(100);

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasMaxLength(100);
			});
		}

	}

}