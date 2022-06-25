using System.ComponentModel.DataAnnotations;

namespace TL.Bookstore.Model.Books
{
	public class Book
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

		public virtual IEnumerable<BorrrowersCard> BorrrowersCards { get; private set; }

		#endregion
	}
}
