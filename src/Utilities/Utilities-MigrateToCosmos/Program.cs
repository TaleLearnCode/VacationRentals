using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaleLearnCode.VacationRentals.Relational;

namespace TaleLearnCode.VacationRentals.Utilities.MigrateToCosmos
{
	class Program
	{

		static async Task Main(string[] args)
		{
			ShowBanner();
			AppSettings appSettings = GetAppSettings();
			if (appSettings != default)
			{

				using VacationRentalsContext vacationRentalsContext = new(appSettings);
				using CosmosClient cosmosClient = new(appSettings.CosmosEndpointUrl, appSettings.CosmosKey);

				Database cosmosDatabase = await GetCosmosDatabase(cosmosClient, "VacationRentals", true);

				Container referenceTypesContainer = await GetCosmosContainer(cosmosDatabase, "ReferenceTypes", "referenceTypeName");
				Container userAccountContainer = await GetCosmosContainer(cosmosDatabase, "UserAccounts", "userAccountId");
				Container attributesContainer = await GetCosmosContainer(cosmosDatabase, "Attributes", "attributeTypeId");
				Container propertiesContainer = await GetCosmosContainer(cosmosDatabase, "Properties", "propertyId");

				await MigrateCountries(vacationRentalsContext, referenceTypesContainer);
				await MigrateCountryDivisions(vacationRentalsContext, referenceTypesContainer);
				await MigrateLanguageCultures(vacationRentalsContext, referenceTypesContainer);
				await MigratePhoneNumberTypes(vacationRentalsContext, referenceTypesContainer);
				await MigratePostalAddressTypes(vacationRentalsContext, referenceTypesContainer);
				await MigratePropertyTypes(vacationRentalsContext, referenceTypesContainer);
				await MigrateRoomTypes(vacationRentalsContext, referenceTypesContainer);
				await MigrateUserAccounts(vacationRentalsContext, userAccountContainer);
				await MigrateAttributeDataTypes(vacationRentalsContext, referenceTypesContainer);
				await MigrateAtributeCategories(vacationRentalsContext, referenceTypesContainer);
				await MigrateAttributeTypes(vacationRentalsContext, attributesContainer);
				await MigrateProperties(vacationRentalsContext, propertiesContainer);
				await MigrateRentalRates(vacationRentalsContext, propertiesContainer);
			}

		}

		private static void ShowBanner()
		{
			Console.Clear();
			WriteLine(@"   _____  .__                     __             __           _________                                    ", ConsoleColor.Blue);
			WriteLine(@"  /     \ |__| ________________ _/  |_  ____   _/  |_  ____   \_   ___ \  ____  ______ _____   ____  ______", ConsoleColor.Blue);
			WriteLine(@" /  \ /  \|  |/ ___\_  __ \__  \\   __\/ __ \  \   __\/  _ \  /    \  \/ /  _ \/  ___//     \ /  _ \/  ___/", ConsoleColor.Blue);
			WriteLine(@"/    Y    \  / /_/  >  | \// __ \|  | \  ___/   |  | (  <_> ) \     \___(  <_> )___ \|  Y Y  (  <_> )___ \ ", ConsoleColor.Blue);
			WriteLine(@"\____|__  /__\___  /|__|  (____  /__|  \___  >  |__|  \____/   \______  /\____/____  >__|_|  /\____/____  >", ConsoleColor.Blue);
			WriteLine(@"        \/  /_____/            \/          \/                         \/           \/      \/           \/ ", ConsoleColor.Blue);
			Console.WriteLine();
		}

		private static void ShowSectionHeader(string message)
		{
			Console.WriteLine();
			Console.WriteLine();
			WriteLine("--------------------------------------------------------", ConsoleColor.Green);
			WriteLine(message, ConsoleColor.Green);
			WriteLine("--------------------------------------------------------", ConsoleColor.Green);
			Console.WriteLine();
			Console.WriteLine();
		}

		private static string GetInput(string prompt)
		{
			Console.WriteLine();
			Console.WriteLine(prompt);
			return ReadLine(true);
		}

		private static string ReadLine(bool intercept)
		{
			if (intercept)
			{
				StringBuilder input = new();
				while (true)
				{
					var key = Console.ReadKey(true);
					if (key.Key == ConsoleKey.Enter)
						break;
					if (key.Key == ConsoleKey.Escape)
						return string.Empty;
					if (key.Key == ConsoleKey.Backspace && input.Length > 0)
						input.Remove(input.Length - 1, 1);
					else if (key.Key != ConsoleKey.Backspace)
						input.Append(key.KeyChar);
				}
				return input.ToString();
			}
			else
				return Console.ReadLine();
		}

		private static void WriteLine(string value, ConsoleColor foregroundColor)
		{
			ConsoleColor originalForegroundColor = Console.ForegroundColor;
			Console.ForegroundColor = foregroundColor;
			Console.WriteLine(value);
			Console.ForegroundColor = originalForegroundColor;
		}

		private static AppSettings GetAppSettings()
		{
			string sqlConnectionString = GetInput("SQL Server Connection String: ");
			if (!string.IsNullOrWhiteSpace(sqlConnectionString))
			{
				string cosmosEndpointUrl = GetInput("Cosmos Endpoint Url: ");
				if (!string.IsNullOrWhiteSpace(cosmosEndpointUrl))
				{
					string cosmosKey = GetInput("Cosmos Key: ");
					if (!string.IsNullOrWhiteSpace(cosmosKey))
					{
						return new AppSettings()
						{
							SQLConnectionString = sqlConnectionString,
							CosmosEndpointUrl = cosmosEndpointUrl,
							CosmosKey = cosmosKey
						};
					}
					else
					{
						return default;
					}
				}
				else
				{
					return default;
				}
			}
			else
			{
				return default;
			}

		}

		private static async Task<Database> GetCosmosDatabase(CosmosClient cosmosClient, string databaseName, bool deleteIfExists)
		{
			Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
			if (deleteIfExists)
			{
				await database.DeleteAsync();
				database = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseName);
			}
			Console.WriteLine($"Created Database: {database.Id}");
			return database;
		}

		private static async Task<Container> GetCosmosContainer(Database database, string containerName, string partitionKey)
		{
			Container container = await database.CreateContainerIfNotExistsAsync(containerName, $"/{partitionKey}");
			Console.WriteLine($"Created Container: {container.Id}");
			return container;
		}

		private static async Task MigrateCountries(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Countries");

			List<Relational.Entities.Country> countries = context.Countries.Include(x => x.CountryDivisions).ToList();
			foreach (Relational.Entities.Country country in countries)
			{
				Console.WriteLine($"Migrating Country: {country.CountryName}");
				NoSQL.Entities.ReferenceTypes.Country cosmosCountry = country.ToNoSQLEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.Country> itemResponse = await container.CreateItemAsync<NoSQL.Entities.ReferenceTypes.Country>(cosmosCountry, new PartitionKey(cosmosCountry.ReferenceTypeName));
					Console.WriteLine($"Created Country ({itemResponse.Resource.Code}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Country {cosmosCountry.Code} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Country {cosmosCountry.Name}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateCountryDivisions(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Country Divisions");

			List<Relational.Entities.CountryDivision> countryDivisions = context.CountryDivisions.ToList();
			foreach (Relational.Entities.CountryDivision countryDivision in countryDivisions)
			{
				Console.WriteLine($"Migrating Country Division: {countryDivision.CountryDivisionName}");
				NoSQL.Entities.ReferenceTypes.CountryDivision cosmosCountryDivision = countryDivision.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.CountryDivision> itemResponse = await container.CreateItemAsync(cosmosCountryDivision, new PartitionKey(cosmosCountryDivision.ReferenceTypeName));
					Console.WriteLine($"Created Country Division ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Country Division {cosmosCountryDivision.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Country Division {cosmosCountryDivision.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateLanguageCultures(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Language Cultures");

			List<Relational.Entities.LanguageCulture> languageCultures = context.LanguageCultures.ToList();
			foreach (Relational.Entities.LanguageCulture languageCulture in languageCultures)
			{
				Console.WriteLine($"Migrating Country Division: {languageCulture.EnglishName}");
				NoSQL.Entities.ReferenceTypes.LanguageCulture cosmosLanguageCulture = languageCulture.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.LanguageCulture> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Language Culture ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Language Culture {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Language Culture {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigratePhoneNumberTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Phone Number Types");

			List<Relational.Entities.PhoneNumberType> phoneNumberTypes = context.PhoneNumberTypes.ToList();
			foreach (Relational.Entities.PhoneNumberType phoneNumberType in phoneNumberTypes)
			{
				Console.WriteLine($"Migrating Phone Number Type: {phoneNumberType.PhoneNumberTypeName}");
				NoSQL.Entities.ReferenceTypes.ReferenceType cosmosLanguageCulture = phoneNumberType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.ReferenceType> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Phone Number Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Phone Number Type {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Phone Number Type {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigratePostalAddressTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Postal Address Types");

			List<Relational.Entities.PostalAddressType> postalAddressTypes = context.PostalAddressTypes.ToList();
			foreach (Relational.Entities.PostalAddressType postalAddressType in postalAddressTypes)
			{
				Console.WriteLine($"Migrating Postal Address Type: {postalAddressType.PostalAddressTypeName}");
				NoSQL.Entities.ReferenceTypes.ReferenceType cosmosLanguageCulture = postalAddressType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.ReferenceType> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Postal Address Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Postal Address Type {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Postal Address Type {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigratePropertyTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Property Types");

			List<Relational.Entities.PropertyType> propertyTypes =
				context.PropertyTypes
					.Include(x => x.Label)
						.ThenInclude(x => x.ContentCopies)
					.ToList();
			foreach (Relational.Entities.PropertyType propertyType in propertyTypes)
			{
				Console.WriteLine($"Migrating Property Type: {propertyType.PropertyTypeName}");
				NoSQL.Entities.ReferenceTypes.ReferenceType cosmosLanguageCulture = propertyType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.ReferenceType> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Property Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Postal Property {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Property Type {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateRoomTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Room Types");

			List<Relational.Entities.RoomType> roomTypes = context.RoomTypes.ToList();
			foreach (Relational.Entities.RoomType roomType in roomTypes)
			{
				Console.WriteLine($"Migrating Room Type: {roomType.RoomTypeName}");
				NoSQL.Entities.ReferenceTypes.RoomType cosmosLanguageCulture = roomType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.RoomType> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Room Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Room Type {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Room Type {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}

		}

		private static async Task MigrateUserAccounts(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating User Accounts");

			List<Relational.Entities.UserAccount> userAccounts =
				context.UserAccounts
					.Include(x => x.UserAccountPhoneNumbers)
						.ThenInclude(x => x.PhoneNumber)
							.ThenInclude(x => x.PhoneNumberType)
					.Include(x => x.UserAccountPostalAddresses)
						.ThenInclude(x => x.PostalAddress)
							.ThenInclude(x => x.PostalAddressType)
					.Include(x => x.UserAccountPostalAddresses)
						.ThenInclude(x => x.PostalAddress)
							.ThenInclude(x => x.Country)
					.Include(x => x.UserAccountPostalAddresses)
						.ThenInclude(x => x.PostalAddress)
							.ThenInclude(x => x.CountryCodeNavigation)
					.ToList();

			foreach (Relational.Entities.UserAccount userAccount in userAccounts)
			{
				Console.WriteLine($"Migraing User Account: {userAccount.FirstName} {userAccount.LastName}");
				NoSQL.Entities.UserAccounts.UserAccount cosmosUserAccount = userAccount.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.UserAccounts.UserAccount> itemResponse = await container.CreateItemAsync(cosmosUserAccount, new PartitionKey(cosmosUserAccount.Id));
					Console.WriteLine($"Created User Account ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"User Account {cosmosUserAccount.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating User Account {cosmosUserAccount.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}

		}

		private static async Task MigrateAttributeDataTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Attribute Data Types");

			List<Relational.Entities.AttributeDataType> attributeDataTypes = context.AttributeDataTypes.ToList();
			foreach (Relational.Entities.AttributeDataType attributeDataType in attributeDataTypes)
			{
				Console.WriteLine($"Migrating Attribute Data Type: {attributeDataType.AttributeDataTypeName}");
				NoSQL.Entities.ReferenceTypes.ReferenceType cosmosLanguageCulture = attributeDataType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.ReferenceType> itemResponse = await container.CreateItemAsync(cosmosLanguageCulture, new PartitionKey(cosmosLanguageCulture.ReferenceTypeName));
					Console.WriteLine($"Created Attribute Data Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Attribute Data Type {cosmosLanguageCulture.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Attribute Data Type {cosmosLanguageCulture.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateAtributeCategories(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Attribute Categories");

			List<Relational.Entities.AttributeCategory> attributeDataTypes = context.AttributeCategories.ToList();
			foreach (Relational.Entities.AttributeCategory attributeDataType in attributeDataTypes)
			{
				Console.WriteLine($"Migrating Attribute Category: {attributeDataType.AttributeCategoryName}");
				NoSQL.Entities.ReferenceTypes.ReferenceType attributeCategory = attributeDataType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.ReferenceTypes.ReferenceType> itemResponse = await container.CreateItemAsync(attributeCategory, new PartitionKey(attributeCategory.ReferenceTypeName));
					Console.WriteLine($"Created Attribute Category ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Attribute Category {attributeCategory.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Attribute Category {attributeCategory.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateAttributeTypes(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Attribute Types");

			List<Relational.Entities.AttributeType> attributeTypes =
				context.AttributeTypes
					.Include(x => x.AttributeLookupValues)
						.ThenInclude(x => x.PossibleValue)
							.ThenInclude(x => x.ContentCopies)
					.Include(x => x.AttributeCategory)
					.Include(x => x.AttributeDataType)
					.Include(x => x.Label)
						.ThenInclude(x => x.ContentCopies)
					.ToList();
			foreach (Relational.Entities.AttributeType attributeType in attributeTypes)
			{
				Console.WriteLine($"Migrating Attribute Type: {attributeType.AttributeTypeName}");
				NoSQL.Entities.Attributes.AttributeType cosmosAttributeType = attributeType.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.Attributes.AttributeType> itemResponse = await container.CreateItemAsync(cosmosAttributeType, new PartitionKey(cosmosAttributeType.AttributeTypeId));
					Console.WriteLine($"Created Attribute Type ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Attribute Type {cosmosAttributeType.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Attribute Category {cosmosAttributeType.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateProperties(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Properties");

			List<Relational.Entities.Property> properties =
				context.Properties
					.Include(x => x.Description)
						.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Headline)
						.ThenInclude(x => x.ContentCopies)
					.Include(x => x.PostalAddress)
						.ThenInclude(x => x.Country)
					.Include(x => x.PostalAddress)
						.ThenInclude(x => x.CountryCodeNavigation)
					.Include(x => x.PostalAddress)
						.ThenInclude(x => x.PostalAddressType)
					.Include(x => x.PropertyName)
						.ThenInclude(x => x.ContentCopies)
					.Include(x => x.PropertyType)
						.ThenInclude(x => x.Label)
							.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Summary)
						.ThenInclude(x => x.ContentCopies)
					.Include(x => x.UserAccount)
					.Include(x => x.PropertyAttributes)
						.ThenInclude(x => x.Attribute)
							.ThenInclude(x => x.AttributeType)
								.ThenInclude(x => x.Label)
									.ThenInclude(x => x.ContentCopies)
					.Include(x => x.PropertyAttributes)
						.ThenInclude(x => x.Attribute)
							.ThenInclude(x => x.AttributeLookupValue)
								.ThenInclude(x => x.PossibleValue)
									.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Rooms)
						.ThenInclude(x => x.Description)
							.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Rooms)
						.ThenInclude(x => x.RoomName)
							.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Rooms)
						.ThenInclude(x => x.RoomType)
					.Include(x => x.Rooms)
						.ThenInclude(x => x.RoomAttributes)
							.ThenInclude(x => x.Attribute)
								.ThenInclude(x => x.AttributeType)
									.ThenInclude(x => x.Label)
										.ThenInclude(x => x.ContentCopies)
					.Include(x => x.Rooms)
						.ThenInclude(x => x.RoomAttributes)
							.ThenInclude(x => x.Attribute)
								.ThenInclude(x => x.AttributeLookupValue)
									.ThenInclude(x => x.PossibleValue)
										.ThenInclude(x => x.ContentCopies)
					.ToList();
			foreach (Relational.Entities.Property property in properties)
			{
				Console.WriteLine($"Migrating Property: {property.PropertyId}");
				NoSQL.Entities.Properties.Property cosmosProperty = property.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.Properties.Property> itemResponse = await container.CreateItemAsync(cosmosProperty, new PartitionKey(cosmosProperty.PropertyId));
					Console.WriteLine($"Created Property ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Property {cosmosProperty.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Property {cosmosProperty.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}

		private static async Task MigrateRentalRates(VacationRentalsContext context, Container container)
		{
			ShowSectionHeader("Migrating Rental Rates");

			List<Relational.Entities.RentalRate> rentalRates = context.RentalRates.ToList();
			foreach (Relational.Entities.RentalRate rentalRate in rentalRates)
			{
				Console.WriteLine($"Migrating Rental Rate: {rentalRate.RentalRateId}");
				NoSQL.Entities.Properties.RentalRate cosmosRentalRate = rentalRate.ToNoSqlEntity();
				try
				{
					ItemResponse<NoSQL.Entities.Properties.RentalRate> itemResponse = await container.CreateItemAsync(cosmosRentalRate, new PartitionKey(cosmosRentalRate.PropertyId));
					Console.WriteLine($"Created Rental Rate ({itemResponse.Resource.Id}); Operation consumed {itemResponse.RequestCharge} RUs.");
				}
				catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.Conflict)
				{
					WriteLine($"Rental Rate {cosmosRentalRate.Id} already exists", ConsoleColor.Yellow);
				}
				catch (Exception ex)
				{
					WriteLine($"Error migrating Rental Rate {cosmosRentalRate.Id}: {ex.Message}", ConsoleColor.Red);
				}
			}


		}



	}

}