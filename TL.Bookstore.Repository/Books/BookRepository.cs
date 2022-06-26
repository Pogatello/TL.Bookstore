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

		public async Task<Book> GetBookByIsbnAsync(string isbn)
		{
			return await _dbContext.Books
				.Include(x=> x.BorrrowersCards)
				.SingleOrDefaultAsync(x => x.Isbn == isbn);
		}

		public async Task<IEnumerable<Book>> GetBorrowedBooksAsync(long customerId)
		{
			return await _dbContext.Books
				.Where(x => x.BorrrowersCards.Any(x => x.IsBorrowed && x.CustomerId == customerId))
				.ToListAsync();
		}

		public async Task UpdateBookAsync(Book book)
		{
			_dbContext.Books.Update(book);
			await _dbContext.SaveChangesAsync();
		}

		#endregion
	}
}
