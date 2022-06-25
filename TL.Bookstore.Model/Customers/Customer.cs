using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Model.Customers
{
	public class Customer
	{
		#region Properties
		
		public long Id { get; private set; }

		public string Username { get; private set; }

		#endregion

		#region Navigation Properties

		public virtual IEnumerable<BorrrowersCard> BorrrowersCards { get; private set; }

		#endregion
	}
}
