using TaleLearnCode.VacationRentals.Relational;

namespace TaleLearnCode.VacationRentals.Utilities.MigrateToCosmos
{

	public class AppSettings : ISQLSettings
	{

		public string SQLConnectionString { get; set; }

		public string CosmosEndpointUrl { get; set; }

		public string CosmosKey { get; set; }

	}

}