using TL.Bookstore.Model.Customers;

namespace TL.Bookstore.Model.Books
{
	public class BorrrowersCard
	{
		#region Properties

		public long Id { get; private set; }

		public bool IsBorrowed { get; private set; }

		#endregion

		#region Navigation Properties

		public long BookId { get; private set; }

		public virtual Book Book { get; private set; }

		public long CustomerId { get; private set; }

		public virtual Customer Customer { get; private set; }

		#endregion
	}
}
