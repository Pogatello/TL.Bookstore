using TL.Bookstore.Model.Books.Query;

namespace TL.Bookstore.Model.Books
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> GetAvailableBooksAsync(GetBooksQuery query);

		Task<Book> GetBookByIsbnAsync(string isbn);

		Task<IEnumerable<Book>> GetBorrowedBooksAsync(string username);

		Task CreateBooksAsync(IEnumerable<Book> books);

		Task UpdateBookAsync(Book book);
	}
}
