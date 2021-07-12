using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class LocalizedAttributeValueListing : Dictionary<string, LocalizedAttributeValueByType>
	{

		public new void Add(string categoryId, LocalizedAttributeValueByType attributeValues)
		{
			base.Add(categoryId, attributeValues);
		}

		public new bool TryGetValue(string categoryid, out LocalizedAttributeValueByType attributeValues)
		{
			return base.TryGetValue(categoryid, out attributeValues);
		}

		public new bool ContainsKey(string categoryId)
		{
			return base.ContainsKey(categoryId);
		}

		public new LocalizedAttributeValueByType this[string categoryId]
		{
			get { return base[categoryId]; }
			set { base[categoryId] = value; }
		}

	}

}