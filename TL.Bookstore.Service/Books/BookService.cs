using TL.Bookstore.Contract.Books;
using TL.Bookstore.Infrastructure;
using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Books.Query;
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

		public async Task<GetAvailableBooksResponse> GetAvailableBooksAsync(GetAvailableBooksRequest request)
		{
			var query = new GetBooksQuery(request.PageNumber, request.ItemsPerPage);
			query.Validate();

			var books = await _bookRepository.GetAvailableBooksAsync(query);

			return _bookFactory.CreateGetAvailableBooksResponse(books);
		}

		public async Task<GetBookResponse> GetBookByIsbnAsync(GetBookRequest request)
		{
			var book = await _bookRepository.GetBookByIsbnAsync(request.Isbn);

			if(book == null)
			{
				throw new ResourceNotFoundException();
			}

			return _bookFactory.CreateGetBookResponse(book);
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
