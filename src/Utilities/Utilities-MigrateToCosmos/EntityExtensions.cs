using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Utilities.MigrateToCosmos
{
	public static class EntityExtensions
	{

		public static NoSQL.Entities.ReferenceTypes.Country ToNoSQLEntity(this Relational.Entities.Country country)
		{
			if (country != default)
			{
				NoSQL.Entities.ReferenceTypes.CountryDivisionListing countryDivisions = new();
				ICollection<Relational.Entities.CountryDivision> something = country.CountryDivisions;

				return new NoSQL.Entities.ReferenceTypes.Country()
				{
					Code = country.CountryCode,
					Name = country.CountryName,
					DivisionName = (country.HasDivisions) ? country.DivisionName : null,
					Divisions = (country.HasDivisions) ? country.CountryDivisions.ToNoSQLEntity() : null,
					IsDeleted = !country.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.CountryDivisionListing ToNoSQLEntity(this ICollection<Relational.Entities.CountryDivision> countryDivisions)
		{
			if (countryDivisions != default)
			{
				NoSQL.Entities.ReferenceTypes.CountryDivisionListing response = new();
				foreach (Relational.Entities.CountryDivision countryDivision in countryDivisions)
					response.Add(countryDivision.CountryDivisionCode, new NoSQL.Entities.ReferenceTypes.CountryListingItem()
					{
						Code = countryDivision.CountryDivisionCode,
						Name = countryDivision.CountryDivisionName,
						Category = countryDivision.CategoryName
					});
				return response;
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.CountryDivision ToNoSqlEntity(this Relational.Entities.CountryDivision countryDivision)
		{
			if (countryDivision != default)
			{
				return new NoSQL.Entities.ReferenceTypes.CountryDivision(countryDivision.CountryCode, countryDivision.CountryDivisionCode)
				{
					Name = countryDivision.CountryDivisionName,
					Category = countryDivision.CategoryName,
					IsDeleted = !countryDivision.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.LanguageCulture ToNoSqlEntity(this Relational.Entities.LanguageCulture languageCulture)
		{
			if (languageCulture != default)
			{
				return new NoSQL.Entities.ReferenceTypes.LanguageCulture()
				{
					Id = languageCulture.LanguageCultureId,
					LanguageCode = languageCulture.LanguageCode,
					EnglishName = languageCulture.EnglishName,
					NativeName = languageCulture.NativeName,
					IsDeleted = !languageCulture.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.PhoneNumberType phoneNumberType)
		{
			if (phoneNumberType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"PhoneNumberType-{phoneNumberType.PhoneNumberTypeId}",
					ReferenceTypeName = "PhoneNumberType",
					Name = new() { { "en-US", phoneNumberType.PhoneNumberTypeName } },
					SystemName = phoneNumberType.PhoneNumberTypeName,
					SortOrder = phoneNumberType.SortOrder,
					IsDeleted = !phoneNumberType.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.PostalAddressType phoneNumberType)
		{
			if (phoneNumberType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"PostalAddressType-{phoneNumberType.PostalAddressTypeId}",
					ReferenceTypeName = "PostalAddressType",
					Name = new() { { "en-US", phoneNumberType.PostalAddressTypeName } },
					SystemName = phoneNumberType.PostalAddressTypeName,
					SortOrder = phoneNumberType.SortOrder,
					IsDeleted = !phoneNumberType.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.PropertyType propertyType)
		{
			if (propertyType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"PropertyType-{propertyType.PropertyTypeId}",
					ReferenceTypeName = "PropertyType",
					SystemName = propertyType.PropertyTypeName,
					Name = propertyType.Label?.ContentCopies?.ToNoSqlContentCopy(),
					IsDeleted = !propertyType.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ContentCopy ToNoSqlContentCopy(this ICollection<Relational.Entities.ContentCopy> contentCopies)
		{
			if (contentCopies != default)
			{
				NoSQL.Entities.ContentCopy response = new();
				foreach (Relational.Entities.ContentCopy contentCopy in contentCopies)
					response.Add(contentCopy.LanguageCultureId, contentCopy.CopyText);
				return response;
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.RoomType ToNoSqlEntity(this Relational.Entities.RoomType roomType)
		{
			if (roomType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.RoomType()
				{
					Id = $"RoomType-{roomType.RoomTypeId}",
					ReferenceTypeName = "RoomType",
					Name = new() { { "en-US", roomType.RoomTypeName } },
					SystemName = roomType.RoomTypeName,
					SortOrder = roomType.SortOrder,
					IsDeleted = !roomType.IsActive
				};
			}
			else
				return default;
		}


	}

}