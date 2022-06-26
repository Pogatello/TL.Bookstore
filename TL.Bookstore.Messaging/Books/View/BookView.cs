namespace TL.Bookstore.Messaging.Books.View
{
	public class BookView
	{
		public long Id { get; set; }

		public long BookId { get; set; }

		public string Title { get; set; }

		public string Authors { get; set; }

		public decimal AverageRating { get; set; }

		public string Isbn { get; set; }

		public string Isbn13 { get; set; }

		public string Language { get; set; }

		public int PageNumbers { get; set; }

		public int RatingsCount { get; set; }

		public int TextReviewsCount { get; set; }

		public DateTime PublicationDate { get; set; }

		public string Publisher { get; set; }
	}
}
