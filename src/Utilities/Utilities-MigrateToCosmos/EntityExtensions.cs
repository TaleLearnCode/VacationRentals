using System.Collections.Generic;
using System.Linq;

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

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.PostalAddressType postalAddressType)
		{
			if (postalAddressType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"PostalAddressType-{postalAddressType.PostalAddressTypeId}",
					ReferenceTypeName = "PostalAddressType",
					Name = new() { { "en-US", postalAddressType.PostalAddressTypeName } },
					SystemName = postalAddressType.PostalAddressTypeName,
					SortOrder = postalAddressType.SortOrder,
					IsDeleted = !postalAddressType.IsActive
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

		public static NoSQL.Entities.UserAccounts.UserAccount ToNoSqlEntity(this Relational.Entities.UserAccount userAccount)
		{
			if (userAccount != default)
			{
				return new()
				{
					Id = $"UserAccount-{userAccount.UserAccountId}",
					FirstName = userAccount.FirstName,
					LastName = userAccount.LastName,
					PhoneNumbers = userAccount.UserAccountPhoneNumbers.ToNoSqlEntity(),
					PostalAddresses = userAccount.UserAccountPostalAddresses.ToNoSqlEntity(),
					IsPropertyManager = userAccount.IsPropertyManager,
					IsDeleted = false
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.PhoneNumber ToNoSqlEntity(this Relational.Entities.PhoneNumber phoneNumber)
		{
			if (phoneNumber != default)
			{
				return new()
				{
					PhoneNumberTypeId = $"PhoneNumberType-{phoneNumber.PhoneNumberType.PhoneNumberTypeId}",
					PhoneNumberType = (phoneNumber.PhoneNumberType != default) ? phoneNumber.PhoneNumberType.PhoneNumberTypeName : default,
					CountryCode = phoneNumber.CountryCode,
					Number = phoneNumber.Number,
					IsDeleted = !phoneNumber.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.PostalAddress ToNoSqlEntity(this Relational.Entities.PostalAddress postalAddress)
		{
			if (postalAddress != default)
			{
				return new()
				{
					PostalAddressTypeId = $"PostalAddressType-{postalAddress.PostalAddressType.PostalAddressTypeId}",
					PostalAddressType = (postalAddress.PostalAddressType != default) ? postalAddress.PostalAddressType.PostalAddressTypeName : default,
					StreetAddress1 = postalAddress.StreetAddress1,
					StreetAddress2 = postalAddress.StreetAddress2,
					City = postalAddress.City,
					CountryDivisionCode = postalAddress.CountryDivisionCode,
					CountryDivision = (postalAddress.Country != default) ? postalAddress.Country.CountryDivisionName : default,
					CountryCode = postalAddress.CountryCode,
					Country = (postalAddress.CountryCodeNavigation != default) ? postalAddress.CountryCodeNavigation.CountryName : default,
					IsDeleted = (bool)!postalAddress.IsActive
				};
			}
			else
				return default;
		}

		public static List<NoSQL.Entities.ReferenceTypes.PhoneNumber> ToNoSqlEntity(this ICollection<Relational.Entities.UserAccountPhoneNumber> UserAccountPhoneNumbers)
		{
			if (UserAccountPhoneNumbers != default && UserAccountPhoneNumbers.Any())
			{
				List<NoSQL.Entities.ReferenceTypes.PhoneNumber> response = new();
				foreach (Relational.Entities.UserAccountPhoneNumber userAccountPhoneNumber in UserAccountPhoneNumbers)
					if (userAccountPhoneNumber.PhoneNumber != default)
						response.Add(userAccountPhoneNumber.PhoneNumber.ToNoSqlEntity());
				return response;
			}
			else
				return default;
		}

		public static List<NoSQL.Entities.ReferenceTypes.PostalAddress> ToNoSqlEntity(this ICollection<Relational.Entities.UserAccountPostalAddress> userAccountPostalAddresses)
		{
			if (userAccountPostalAddresses != default && userAccountPostalAddresses.Any())
			{
				List<NoSQL.Entities.ReferenceTypes.PostalAddress> response = new();
				foreach (Relational.Entities.UserAccountPostalAddress userAccountPostalAddress in userAccountPostalAddresses)
					if (userAccountPostalAddress.PostalAddress != default)
						response.Add(userAccountPostalAddress.PostalAddress.ToNoSqlEntity());
				return response;
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.AttributeDataType attributeDataType)
		{
			if (attributeDataType != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"AttributeDataType-{attributeDataType.AttributeDataTypeId}",
					ReferenceTypeName = "AttributeDataType",
					Name = new() { { "en-US", attributeDataType.AttributeDataTypeName } },
					SystemName = attributeDataType.AttributeDataTypeName,
					IsDeleted = !attributeDataType.IsActive
				};
			}
			else
				return default;
		}

		public static NoSQL.Entities.ReferenceTypes.ReferenceType ToNoSqlEntity(this Relational.Entities.AttributeCategory attributeCategorty)
		{
			if (attributeCategorty != default)
			{
				return new NoSQL.Entities.ReferenceTypes.ReferenceType()
				{
					Id = $"AttributeCategory-{attributeCategorty.AttributeCategoryId}",
					ReferenceTypeName = "AttributeDataType",
					Name = new() { { "en-US", attributeCategorty.AttributeCategoryName } },
					SystemName = attributeCategorty.AttributeCategoryName,
					IsDeleted = !attributeCategorty.IsActive
				};
			}
			else
				return default;
		}


	}

}