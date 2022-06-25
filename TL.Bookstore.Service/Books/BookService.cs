using TL.Bookstore.Contract.Books;
using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Service.Books.Factory;

namespace TL.Bookstore.Service.Books
{
	public class BookService : IBookService
	{
		#region Fields

		private readonly IBookRepository _bookRepository;
		private readonly IBookFactory _bookFactory;

		#endregion

		#region Constructors

		public BookService(IBookRepository bookRepository, IBookFactory bookFactory)
		{
			_bookRepository = bookRepository;
			_bookFactory = bookFactory;
		}

		#endregion

		#region IBookService

		public Task<GetAvailableBooksResponse> GetAvailableBooksAsync(GetAvailableBooksRequest request)
		{
			throw new NotImplementedException();
		}

		public async Task<ImportBooksResponse> ImportBooksFromADatasheetAsync(ImportBooksRequest request)
		{
			var books = _bookFactory.CreateBooksFromADatasheet(request.BookDatasheet);
			await _bookRepository.CreateBooksAsync(books);

			return _bookFactory.CreateImportBooksResponse();
		}

		#endregion
	}
}
