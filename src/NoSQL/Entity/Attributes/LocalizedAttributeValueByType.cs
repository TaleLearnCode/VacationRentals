using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.Attributes
{

	public class LocalizedAttributeValueByType : Dictionary<string, LocalizedAttributeValue>
	{

		public new void Add(string attributeTypeId, LocalizedAttributeValue attributeValue)
		{
			base.Add(attributeTypeId, attributeValue);
		}

		public new bool TryGetValue(string attributeTypeId, out LocalizedAttributeValue attributeValue)
		{
			return base.TryGetValue(attributeTypeId, out attributeValue);
		}

		public new bool ContainsKey(string attributeTypeId)
		{
			return base.ContainsKey(attributeTypeId);
		}

		public new LocalizedAttributeValue this[string attributeTypeId]
		{
			get { return base[attributeTypeId]; }
			set { base[attributeTypeId] = value; }
		}

	}

}