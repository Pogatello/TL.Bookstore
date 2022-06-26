using TL.Bookstore.Messaging.Books.View;
using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Response
{
	public class GetBorrowedBooksResponse : ResponseBase
	{
		public IEnumerable<BookView> Books { get; set; }
	}
}
