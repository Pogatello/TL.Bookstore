using TL.Bookstore.Contract.Books;
using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Service.Books
{
	public class BookService : IBookService
	{
		#region Fields

		private readonly IBookRepository _bookRepository;

		#endregion

		#region Constructors

		public BookService(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		#endregion

		#region IBookService

		public Task<GetAvailableBooksResponse> GetAvailableBooksAsync(GetAvailableBooksRequest request)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
