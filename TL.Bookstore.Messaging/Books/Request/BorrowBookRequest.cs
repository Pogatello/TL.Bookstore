using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Request
{
	public class BorrowBookRequest : RequestBase
	{
		public string Isbn { get; set; }
	}
}
