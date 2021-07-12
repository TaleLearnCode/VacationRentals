using System;
using System.Collections.Generic;

namespace TaleLearnCode.VacationRentals.NoSQL.Entities.ReferenceTypes
{

	public class CountryDivisionListing : Dictionary<string, CountryListingItem>
	{

		public new void Add(string code, CountryListingItem countryDivision)
		{
			base.Add(code, countryDivision);
		}

		public new bool TryGetValue(string code, out CountryListingItem countryDivision)
		{
			return base.TryGetValue(code, out countryDivision);
		}

		public new bool ContainsKey(string code)
		{
			return base.ContainsKey(code);
		}

		public new CountryListingItem this[string code]
		{
			get { return base[code]; }
			set { base[code] = value; }
		}

		public static implicit operator CountryDivisionListing(CountryDivision v)
		{
			throw new NotImplementedException();
		}
	}

}