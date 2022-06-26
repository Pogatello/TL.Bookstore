using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Customers;

namespace TL.Bookstore.Repository
{
	public class BookstoreDbContext : DbContext
	{
		#region Properties

		public virtual DbSet<Book> Books { get; set; }

		public virtual DbSet<Customer> Customers { get; set; }

		#endregion

		#region Constructors

		public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
			: base(options)
		{

		}

		#endregion
	}
}
