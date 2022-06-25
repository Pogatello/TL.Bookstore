using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.Response;

namespace TL.Bookstore.Contract.Books
{
	public interface IBookService
	{
		Task<GetAvailableBooksResponse> GetAvailableBooksAsync(GetAvailableBooksRequest request);

		Task<ImportBooksResponse> ImportBooksFromADatasheetAsync(ImportBooksRequest request);
	}
}
