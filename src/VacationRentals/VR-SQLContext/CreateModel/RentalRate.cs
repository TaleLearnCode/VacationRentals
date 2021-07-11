using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.RentalRate"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void RentalRate(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RentalRate>(entity =>
			{
				entity.ToTable("RentalRate");

				entity.HasIndex(e => new { e.StartDate, e.EndDate }, "ixRentalRate");

				entity.Property(e => e.Id)
					.HasColumnName("RentalRateId");

				entity.Property(e => e.EndDate)
					.HasColumnType("date")
					.HasDefaultValueSql("('9999-12-31')");

				entity.Property(e => e.Rate).HasColumnType("decimal(7, 2)");

				entity.Property(e => e.StartDate)
					.HasColumnType("date")
					.HasDefaultValueSql("(getutcdate())");

				entity.HasOne(d => d.Property)
					.WithMany(p => p.RentalRates)
					.HasForeignKey(d => d.PropertyId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRentalRate_Property");
			});
		}

	}

}