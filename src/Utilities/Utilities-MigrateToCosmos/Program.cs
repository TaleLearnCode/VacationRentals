using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaleLearnCode.VacationRentals.Relational;

namespace Utilities_MigrateToCosmos
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowBanner();
			string connectionString = GetConnectionString();
			if (!string.IsNullOrWhiteSpace(connectionString))
			{
				AppSettings appSettings = new() { ConnectionString = connectionString };
				VacationRentalsContext vacationRentalsContext = new(appSettings);
				List<TaleLearnCode.VacationRentals.Relational.Entities.Country> countries = vacationRentalsContext.Countries.Include(x => x.CountryDivisions).ToList();
				foreach (TaleLearnCode.VacationRentals.Relational.Entities.Country country in countries)
					Console.WriteLine(country.CountryName);

			}
		}

		private static void ShowBanner()
		{
			ConsoleColor foregroundColor = Console.ForegroundColor;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine(@"   _____  .__                     __             __           _________                                    ");
			Console.WriteLine(@"  /     \ |__| ________________ _/  |_  ____   _/  |_  ____   \_   ___ \  ____  ______ _____   ____  ______");
			Console.WriteLine(@" /  \ /  \|  |/ ___\_  __ \__  \\   __\/ __ \  \   __\/  _ \  /    \  \/ /  _ \/  ___//     \ /  _ \/  ___/");
			Console.WriteLine(@"/    Y    \  / /_/  >  | \// __ \|  | \  ___/   |  | (  <_> ) \     \___(  <_> )___ \|  Y Y  (  <_> )___ \ ");
			Console.WriteLine(@"\____|__  /__\___  /|__|  (____  /__|  \___  >  |__|  \____/   \______  /\____/____  >__|_|  /\____/____  >");
			Console.WriteLine(@"        \/  /_____/            \/          \/                         \/           \/      \/           \/ ");
			Console.ForegroundColor = foregroundColor;
			Console.WriteLine();
		}

		private static string GetConnectionString()
		{
			Console.WriteLine("SQL Server Connection String: ");
			return ReadLine(true);
		}

		public static string ReadLine(bool intercept)
		{
			if (intercept)
			{
				StringBuilder input = new();
				while (true)
				{
					var key = Console.ReadKey(true);
					if (key.Key == ConsoleKey.Enter)
						break;
					if (key.Key == ConsoleKey.Escape)
						return string.Empty;
					if (key.Key == ConsoleKey.Backspace && input.Length > 0)
						input.Remove(input.Length - 1, 1);
					else if (key.Key != ConsoleKey.Backspace)
						input.Append(key.KeyChar);
				}
				return input.ToString();
			}
			else
				return Console.ReadLine();
		}


	}

}