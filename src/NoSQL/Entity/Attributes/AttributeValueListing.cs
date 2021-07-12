using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class AttributeValueListing : Dictionary<string, AttributeValueByType>
	{

		public new void Add(string categoryId, AttributeValueByType attributeValues)
		{
			base.Add(categoryId, attributeValues);
		}

		public new bool TryGetValue(string categoryid, out AttributeValueByType attributeValues)
		{
			return base.TryGetValue(categoryid, out attributeValues);
		}

		public new bool ContainsKey(string categoryId)
		{
			return base.ContainsKey(categoryId);
		}

		public new AttributeValueByType this[string categoryId]
		{
			get { return base[categoryId]; }
			set { base[categoryId] = value; }
		}

	}

}