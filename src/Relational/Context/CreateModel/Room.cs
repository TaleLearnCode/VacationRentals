using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.Room"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void Room(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Room>(entity =>
			{
				entity.ToTable("Room");

				entity.Property(e => e.Id)
					.HasColumnName("RoomId");

				entity.Property(e => e.IsActive)
					.IsRequired()
					.HasDefaultValueSql("((1))");

				entity.HasOne(d => d.Description)
					.WithMany(p => p.RoomDescriptions)
					.HasForeignKey(d => d.DescriptionId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoom_Content_Description");

				entity.HasOne(d => d.Property)
					.WithMany(p => p.Rooms)
					.HasForeignKey(d => d.PropertyId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoom_Property");

				entity.HasOne(d => d.RoomName)
					.WithMany(p => p.RoomNames)
					.HasForeignKey(d => d.RoomNameId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoom_Content_RoomName");

				entity.HasOne(d => d.RoomType)
					.WithMany(p => p.Rooms)
					.HasForeignKey(d => d.RoomTypeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoom_RoomType");
			});
		}

	}

}