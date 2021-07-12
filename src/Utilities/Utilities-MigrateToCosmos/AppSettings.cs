using TaleLearnCode.VacationRentals.Relational;

namespace Utilities_MigrateToCosmos
{

	public class AppSettings : ISQLSettings
	{
		public string ConnectionString { get; set; }
	}

}