using Microsoft.AspNetCore.Mvc;
using TL.Bookstore.Messaging.Books.View;

namespace TL.Bookstore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{

		#region Constructors

		public BooksController()
		{
				
		}

		#endregion

		#region BooksController

		[HttpGet]
		public async Task<IEnumerable<BookView>> GetAvailableBooksAsync()
		{
			return await Task.FromResult(new List<BookView>());
		}



		#endregion
	}
}