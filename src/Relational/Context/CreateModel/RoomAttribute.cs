using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.RoomAttribute"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void RoomAttribute(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<RoomAttribute>(entity =>
			{
				entity.HasKey(e => new { e.RoomId, e.AttributeId })
					.HasName("pkcRoomAttribute");

				entity.ToTable("RoomAttribute");

				entity.HasOne(d => d.Attribute)
					.WithMany(p => p.RoomAttributes)
					.HasForeignKey(d => d.AttributeId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoomAttribute_Attribute");

				entity.HasOne(d => d.Room)
					.WithMany(p => p.RoomAttributes)
					.HasForeignKey(d => d.RoomId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("fkRoomAttribute_Room");
			});
		}

	}

}