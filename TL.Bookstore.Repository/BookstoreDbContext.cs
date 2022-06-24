using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Repository
{
	public class BookstoreDbContext : DbContext
	{
		#region Properties

		public virtual DbSet<Book> Books { get; set; }

		#endregion

		#region Constructors

		public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
			: base(options)
		{

		}

		#endregion
	}
}
