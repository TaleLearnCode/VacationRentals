using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.PostalAddressType"/>
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void PostalAddressType(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostalAddressType>(entity =>
			{
				entity.ToTable("PostalAddressType");

				entity.Property(e => e.Id)
					.HasColumnName("PostalAddressTypeId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("PostalAddressTypeName")
					.IsRequired()
					.HasMaxLength(100)
					.IsUnicode(false);
			});
		}

	}

}