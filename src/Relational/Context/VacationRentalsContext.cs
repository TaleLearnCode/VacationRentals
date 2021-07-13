using Microsoft.EntityFrameworkCore;
using TaleLearnCode.VacationRentals.Relational.Entities;

namespace TaleLearnCode.VacationRentals.Relational
{

	public partial class VacationRentalsContext : DbContext
	{

		private readonly ISQLSettings _sqlSettings;

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationRentalsContext>"/> class.
		/// </summary>
		/// <param name="sqlSettings">The settings to use for connecting and interacting with the SQL Server database.</param>
		public VacationRentalsContext(ISQLSettings sqlSettings)
		{
			_sqlSettings = sqlSettings;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="VacationRentalsContext"/> class.
		/// </summary>
		/// <param name="options">The <see cref="DbContextOptions{VacationRentalsSQLContext}"/> to use for initializing the context.</param>
		public VacationRentalsContext(DbContextOptions<VacationRentalsContext> options) : base(options) { }

		/// <summary>
		/// Called by Entity Framework while it is configuring the data connection
		/// in order to get the database connection infomration.
		/// </summary>
		/// <param name="optionsBuilder">A builder used to create or modify options for this context.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_sqlSettings.SQLConnectionString, options => options.EnableRetryOnFailure());
			}
		}

		/// <summary>
		/// Called by Entity Framework in order to confiugre the entity model.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			CreateModel.AttributeCategory(modelBuilder);
			CreateModel.AttributeDataType(modelBuilder);
			CreateModel.AttributeLookupValue(modelBuilder);
			CreateModel.AttributeLookupValue(modelBuilder);
			CreateModel.AttributeType(modelBuilder);
			CreateModel.AttributeValue(modelBuilder);
			CreateModel.Content(modelBuilder);
			CreateModel.ContentCopy(modelBuilder);
			CreateModel.ContentType(modelBuilder);
			CreateModel.Country(modelBuilder);
			CreateModel.CountryDivision(modelBuilder);
			CreateModel.LanguageCulture(modelBuilder);
			CreateModel.PhoneNumber(modelBuilder);
			CreateModel.PhoneNumberType(modelBuilder);
			CreateModel.PostalAddress(modelBuilder);
			CreateModel.PostalAddressType(modelBuilder);
			CreateModel.Property(modelBuilder);
			CreateModel.PropertyAttribute(modelBuilder);
			CreateModel.PropertyType(modelBuilder);
			CreateModel.RentalRate(modelBuilder);
			CreateModel.Room(modelBuilder);
			CreateModel.RoomAttribute(modelBuilder);
			CreateModel.RoomType(modelBuilder);
			CreateModel.UserAccount(modelBuilder);
			CreateModel.UserAccountPhoneNumber(modelBuilder);
			CreateModel.UserAccountPostalAddress(modelBuilder);

			OnModelCreatingPartial(modelBuilder);

		}

		/// <summary>
		/// Called when other partial implementations need to add to the model creation.
		/// </summary>
		/// <param name="modelBuilder">Th builder busing used to contruct the model for this context.</param>
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

		public virtual DbSet<AttributeCategory> AttributeCategories { get; set; }
		public virtual DbSet<AttributeDataType> AttributeDataTypes { get; set; }
		public virtual DbSet<AttributeLookupValue> AttributeLookupValues { get; set; }
		public virtual DbSet<AttributeType> AttributeTypes { get; set; }
		public virtual DbSet<AttributeValue> AttributeValues { get; set; }
		public virtual DbSet<Content> Contents { get; set; }
		public virtual DbSet<ContentCopy> ContentCopies { get; set; }
		public virtual DbSet<ContentType> ContentTypes { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<CountryDivision> CountryDivisions { get; set; }
		public virtual DbSet<LanguageCulture> LanguageCultures { get; set; }
		public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
		public virtual DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
		public virtual DbSet<PostalAddress> PostalAddresses { get; set; }
		public virtual DbSet<PostalAddressType> PostalAddressTypes { get; set; }
		public virtual DbSet<Property> Properties { get; set; }
		public virtual DbSet<PropertyAttribute> PropertyAttributes { get; set; }
		public virtual DbSet<PropertyType> PropertyTypes { get; set; }
		public virtual DbSet<RentalRate> RentalRates { get; set; }
		public virtual DbSet<Room> Rooms { get; set; }
		public virtual DbSet<RoomAttribute> RoomAttributes { get; set; }
		public virtual DbSet<RoomType> RoomTypes { get; set; }
		public virtual DbSet<UserAccount> UserAccounts { get; set; }
		public virtual DbSet<UserAccountPhoneNumber> UserAccountPhoneNumbers { get; set; }
		public virtual DbSet<UserAccountPostalAddress> UserAccountPostalAddresses { get; set; }


	}

}