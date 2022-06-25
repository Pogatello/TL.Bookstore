using TL.Bookstore.Messaging.Books.View;
using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Response
{
	public class BorrowBookResponse : ResponseBase
	{
		public BookView Book { get; set; }
	}
}
