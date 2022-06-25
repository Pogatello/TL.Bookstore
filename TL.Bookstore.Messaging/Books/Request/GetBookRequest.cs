using TL.Bookstore.Messaging.Common;

namespace TL.Bookstore.Messaging.Books.Request
{
	public class GetBookRequest : RequestBase
	{
		public string Isbn { get; set; }
	}
}
