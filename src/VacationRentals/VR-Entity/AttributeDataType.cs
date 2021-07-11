﻿using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.Entities
{
	public class AttributeDataType
	{

		public AttributeDataType()
		{
			AttributeTypes = new HashSet<AttributeType>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<AttributeType> AttributeTypes { get; set; }

	}

}