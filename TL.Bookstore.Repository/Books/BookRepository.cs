using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Books.Query;

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

		public async Task<IEnumerable<Book>> GetAvailableBooksAsync(GetBooksQuery query)
		{
			return await _dbContext.Books
						.Where(b => !b.BorrrowersCards.Any(x => x.IsBorrowed))
						.Skip(query.PageNumber * query.ItemsPerPage)
						.Take(query.ItemsPerPage)
						.ToListAsync();
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
