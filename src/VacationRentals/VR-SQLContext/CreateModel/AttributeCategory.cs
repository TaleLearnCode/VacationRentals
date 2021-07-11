﻿using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Entities;

namespace TaleLearnCode.VacationRentals.Contexts
{

	internal static partial class CreateModel
	{

		/// <summary>
		/// Creates the Entity Framework model for <see cref="Entities.AttributeCategory"/>.
		/// </summary>
		/// <param name="modelBuilder">API surface for configuring an Entity Framework Core model.</param>
		internal static void AttributeCategory(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AttributeCategory>(entity =>
			{

				entity.ToTable("AttributeCategory");

				entity.Property(e => e.Id)
					.HasColumnName("AttributeCategoryId")
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.HasColumnName("AttributeCategoryName")
					.IsRequired()
					.HasMaxLength(100);

			});
		}

	}

}