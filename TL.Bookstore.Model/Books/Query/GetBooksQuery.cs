namespace TL.Bookstore.Model.Books.Query
{
	public class GetBooksQuery
	{

		#region Fields

		private const int DefaultPageNumber = 0;
		private const int DefaultItemsPerPage = 30;
		private const int MaxItemsPerPage = 100;


		#endregion

		#region Properties

		public int PageNumber { get; set; }

		public int ItemsPerPage { get; set; }

		#endregion

		#region Constructors

		public GetBooksQuery(int pageNumber, int itemsPerPage)
		{
			PageNumber = pageNumber;
			ItemsPerPage = itemsPerPage;
		}

		#endregion

		#region Public Methods

		public void Validate()
		{
			if (PageNumber <= 0)
			{
				PageNumber = DefaultPageNumber;
			}

			if (ItemsPerPage <= 0)
			{
				ItemsPerPage = DefaultItemsPerPage;
			}

			if (ItemsPerPage > MaxItemsPerPage)
			{
				ItemsPerPage = MaxItemsPerPage;
			}

			//Could throw ex with business rule
		}

		#endregion
	}
}
