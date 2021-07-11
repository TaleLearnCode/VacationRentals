namespace TaleLearnCode.VacationRentals.Relational
{

	/// <summary>
	/// Interface for types representing the settings for connecting/working with the Vacation Rentals SQL Server.
	/// </summary>
	public interface ISQLSettings
	{

		/// <summary>
		/// The connection string to the target SQL Server database.
		/// </summary>
		/// <value>A <c>string</c> representing the connection string to the target SQL Server database.</value>
		string ConnectionString { get; set; }

	}

}