using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Request
{
	public class GetAvailableBooksRequest : RequestBase
	{
		public int PageNumber { get; set; }

		public int ItemsPerPage { get; set; }
	}
}
