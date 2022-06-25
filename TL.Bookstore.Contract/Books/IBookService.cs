using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;

namespace TL.Bookstore.Contract.Books
{
	public interface IBookService
	{
		Task<GetAvailableBooksResponse> GetAvailableBooksAsync(GetAvailableBooksRequest request);

		Task<GetBookResponse> GetBookByIsbnAsync(GetBookRequest request);

		Task<GetBorrowedBooksResponse> GetBorrowedBooksAsync(GetBorrowedBooksRequest request);

		Task<ImportBooksResponse> ImportBooksFromADatasheetAsync(ImportBooksRequest request);

		Task<BorrowBookResponse> BorrowBookAsync(BorrowBookRequest request);
	}
}
