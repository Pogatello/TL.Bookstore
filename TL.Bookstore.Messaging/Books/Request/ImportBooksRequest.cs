using Microsoft.AspNetCore.Http;
using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Request
{
	public class ImportBooksRequest : RequestBase
	{
		public IFormFile BookDatasheet { get; set; }
	}
}
