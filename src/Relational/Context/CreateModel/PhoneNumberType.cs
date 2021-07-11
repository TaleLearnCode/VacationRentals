using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PhoneNumberType"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PhoneNumberType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PhoneNumberType>(entity =>
			{
				entity.ToTable("PhoneNumberType");

				entity.Property(e => e.Id)
					.HasColumnName("PhoneNumberTypeId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("PhoneNumberTypeName")
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);
			});
		}

	}

}