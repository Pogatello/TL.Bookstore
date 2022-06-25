using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Repository.Books
{
	public class BookRepository : IBookRepository
	{

		#region Fields

		private readonly BookstoreDbContext _dbContext;

		#endregion

		#region Constructors 

		public BookRepository(BookstoreDbContext context)
		{
			_dbContext = context;
		}

		#endregion

		#region IBookRepository

		public async Task CreateBooksAsync(IEnumerable<Book> books)
		{
			await _dbContext.Books.AddRangeAsync(books);
			await _dbContext.SaveChangesAsync();
		}

		public Task<IEnumerable<Book>> GetAvailableBooksAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Book> GetBookByISBNAsync(string isbn)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Book>> GetBorrowedBooksAsync(string username)
		{
			throw new NotImplementedException();
		}

		public Task UpdateBookAsync(Book book)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
