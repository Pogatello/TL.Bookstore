using TL.Bookstore.Contract.Books;
using TL.Bookstore.Infrastructure;
using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Books.Query;
using TL.Bookstore.Model.Customers;
using TL.Bookstore.Service.Books.Factory;

namespace TL.Bookstore.Service.Books
{
	public class BookService : IBookService
	{
		#region Fields

		private readonly IBookRepository _bookRepository;
		private readonly IBookFactory _bookFactory;
		private readonly ICustomerRepository _customerRepository;


		#endregion

		#region Constructors

		public BookService(IBookRepository bookRepository, IBookFactory bookFactory, ICustomerRepository customerRepository)
		{
			_bookRepository = bookRepository;
			_bookFactory = bookFactory;
			_customerRepository = customerRepository;
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

		public async Task<GetBorrowedBooksResponse> GetBorrowedBooksAsync(GetBorrowedBooksRequest request)
		{
			var customer = await GetOrCreateCustomerIfNonExistent(request.Username);
			var books = await _bookRepository.GetBorrowedBooksAsync(customer.Id);

			return _bookFactory.CreateGetBorrowedBooksResponse(books);
		}

		public async Task<ImportBooksResponse> ImportBooksFromADatasheetAsync(ImportBooksRequest request)
		{
			var books = _bookFactory.CreateBooksFromADatasheet(request.BookDatasheet);
			await _bookRepository.CreateBooksAsync(books);

			return _bookFactory.CreateImportBooksResponse();
		}

		public async Task<BorrowBookResponse> BorrowBookAsync(BorrowBookRequest request)
		{
			var customer = await GetOrCreateCustomerIfNonExistent(request.Username);
			var book = await _bookRepository.GetBookByIsbnAsync(request.Isbn);

			if(book == null)
			{
				throw new ResourceNotFoundException();
			}

			book.ValidateForBorrowing();
			book.AddNewBorrowerCardEntry(customer.Id);

			await _bookRepository.UpdateBookAsync(book);

			return _bookFactory.CreateBorrowBookResponse(book);
		}

		#endregion

		#region Private Methods

		private async Task<Customer> GetOrCreateCustomerIfNonExistent(string username)
		{
			// Could be inside seperate customer service
			var customer = await _customerRepository.GetCustomerByUsernameAsync(username);

			if(customer == null)
			{
				customer = new Customer(username);
				customer.ValidateForCreate();

				await _customerRepository.CreateCustomerAsync(customer);
			}

			return customer;
		}

		#endregion
	}
}
