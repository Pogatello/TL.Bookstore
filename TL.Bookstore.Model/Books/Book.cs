using System.ComponentModel.DataAnnotations;
using TL.Bookstore.Infrastructure.Helpers;
using TL.Bookstore.Model.Books.BusinesRules;
using TL.Bookstore.Model.Common;

namespace TL.Bookstore.Model.Books
{
	public class Book : ValidationEntity
	{
		#region Properties

		[Key]
		public long Id { get; private set; }

		public long BookId { get; private set; }

		public string Title { get; private set; }

		public string Authors { get; private set; }

		public decimal AverageRating { get; private set; }

		public string Isbn { get; private set; }

		public string Isbn13 { get; private set; }

		public string Language { get; private set; }

		public int PageNumbers { get; private set; }

		public int RatingsCount { get; private set; }

		public int TextReviewsCount { get; private set; }

		public DateTime PublicationDate { get; private set; }

		public string Publisher { get; private set; }

		#endregion

		#region Navigation Properties

		public virtual List<BorrrowersCard> BorrrowersCards { get; private set; }

		#endregion

		#region Public Methods

		public void ValidateForBorrowing()
		{
			if (BorrrowersCards.HasElements() && BorrrowersCards.Any(x=>x.IsBorrowed))
			{
				AddBrokenRule(BookBusinessRules.BookAlreadyBorrowedRule);
			}

			ThrowExceptionIfThereAreBrokenRules();
		}

		public void AddNewBorrowerCardEntry(long customerId)
		{
			var newEntry = new BorrrowersCard(true, customerId, Id);
			BorrrowersCards.Add(newEntry);			
		}

		#endregion
	}
}
