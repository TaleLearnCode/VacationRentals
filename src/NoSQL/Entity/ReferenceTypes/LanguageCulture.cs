using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class LanguageCulture
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "referenceTypeName")]
		public string ReferenceTypeName => "LanguageCulture";

		[JsonProperty(PropertyName = "languageCode")]
		public string LanguageCode { get; set; }

		[JsonProperty(PropertyName = "englishName")]
		public string EnglishName { get; set; }

		[JsonProperty(PropertyName = "nativeName")]
		public string NativeName { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}