using System.ComponentModel.DataAnnotations;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Model.Customers
{
	public class Customer
	{
		#region Properties
		
		[Key]
		public long Id { get; private set; }

		public string Username { get; private set; }

		#endregion

		#region Navigation Properties

		public virtual IEnumerable<BorrrowersCard> BorrrowersCards { get; private set; }

		#endregion

		#region Constructors

		public Customer()
		{

		}

		public Customer(string username) : base()
		{
			Username = username;
		}

		#endregion
	}
}
