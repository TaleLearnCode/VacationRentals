using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities
{

	public class ContentCopy : Dictionary<string, string>
	{

		public new void Add(string languageCultureId, string copy)
		{
			base.Add(languageCultureId, copy);
		}

		public new bool TryGetValue(string languageCultureId, out string copy)
		{
			return base.TryGetValue(languageCultureId, out copy);
		}

		public new bool ContainsKey(string languageCultureId)
		{
			return base.ContainsKey(languageCultureId);
		}

		public new string this[string languageCultureId]
		{
			get { return base[languageCultureId]; }
			set { base[languageCultureId] = value; }
		}

	}

}