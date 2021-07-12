using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class AttributeValueByType : Dictionary<string, AttributeValue>
	{
		public new void Add(string attributeTypeId, AttributeValue attributeValue)
		{
			base.Add(attributeTypeId, attributeValue);
		}

		public new bool TryGetValue(string attributeTypeId, out AttributeValue attributeValue)
		{
			return base.TryGetValue(attributeTypeId, out attributeValue);
		}

		public new bool ContainsKey(string attributeTypeId)
		{
			return base.ContainsKey(attributeTypeId);
		}

		public new AttributeValue this[string attributeTypeId]
		{
			get { return base[attributeTypeId]; }
			set { base[attributeTypeId] = value; }
		}

	}

}