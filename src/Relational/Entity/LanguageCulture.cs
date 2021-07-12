using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Relational.Entities
{
	public partial class LanguageCulture
	{
		public LanguageCulture()
		{
			ContentCopies = new HashSet<ContentCopy>();
		}

		public string LanguageCultureId { get; set; }
		public string LanguageCode { get; set; }
		public string EnglishName { get; set; }
		public string NativeName { get; set; }
		public bool IsActive { get; set; }

		public virtual ICollection<ContentCopy> ContentCopies { get; set; }
	}
}