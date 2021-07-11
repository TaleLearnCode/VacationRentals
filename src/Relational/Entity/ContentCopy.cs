namespace TaleLearnCode.VacationRentals.Relational.Entities
{

	public class ContentCopy
	{

		public int ContentId { get; set; }

		public string LanguageCultureId { get; set; }

		public string CopyText { get; set; }

		public virtual Content Content { get; set; }

		public virtual LanguageCulture LanguageCulture { get; set; }

	}

}