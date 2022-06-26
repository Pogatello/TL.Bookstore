using System.ComponentModel.DataAnnotations;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Common;
using TL.Bookstore.Model.Customers.BusinessRules;

namespace TL.Bookstore.Model.Customers
{
	public class Customer : ValidationEntity
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

		#region PublicMethods

		public void ValidateForCreate()
		{
			if (string.IsNullOrWhiteSpace(Username))
			{
				AddBrokenRule(CustomerBusinessRules.UsernameCannotBeEmpty);
			}

			ThrowExceptionIfThereAreBrokenRules();
		}

		#endregion
	}
}
