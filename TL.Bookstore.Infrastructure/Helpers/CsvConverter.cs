using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace TL.Bookstore.Infrastructure.Helpers
{
	public static class CsvConverter
	{
		public static IEnumerable<T> ConvertFileToRecords<T>(IFormFile file)
		{
			using (var reader = new StreamReader(file.OpenReadStream()))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				var response = csv.GetRecords<T>();
				var a = response.ToList();
				return a;
			}
		}
	}
}
