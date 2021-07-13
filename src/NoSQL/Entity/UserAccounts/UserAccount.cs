using Newtonsoft.Json;
using System.Collections.Generic;
using TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.UserAccounts
{

	public class UserAccount
	{

		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "userAccountId")]
		public string UserAccountId => Id;

		[JsonProperty(PropertyName = "firstName")]
		public string FirstName { get; set; }

		[JsonProperty(PropertyName = "lastName")]
		public string LastName { get; set; }

		[JsonProperty(PropertyName = "isPropertyManager")]
		public bool IsPropertyManager { get; set; }

		[JsonProperty(PropertyName = "phoneNumbers")]
		public List<PhoneNumber> PhoneNumbers { get; set; }

		[JsonProperty(PropertyName = "postalAddresses")]
		public List<PostalAddress> PostalAddresses { get; set; }

		[JsonProperty(PropertyName = "isDeleted")]
		public bool IsDeleted { get; set; }

	}

}