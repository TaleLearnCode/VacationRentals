using Newtonsoft.Json;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class RoomType : ReferenceType
	{

		[JsonProperty(PropertyName = "canHaveMultiple")]
		public bool CanHaveMultiple { get; set; }

	}

}