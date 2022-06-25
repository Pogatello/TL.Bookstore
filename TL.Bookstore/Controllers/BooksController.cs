using Microsoft.AspNetCore.Mvc;
using TL.Bookstore.Contract.Books;
using TL.Bookstore.Messaging.Books.Request;
using TL.Bookstore.Messaging.Books.View;

namespace TL.Bookstore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		#region Fields

		private readonly IBookService _bookService;

		#endregion

		#region Constructors

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}

		#endregion

		#region BooksController

		[HttpPost("ImportBooks")]
		public async Task<IActionResult> ImportBooksAsync(IFormFile bookDatasheet)
		{
			if (bookDatasheet == null || bookDatasheet.Length == 0)
			{
				return BadRequest();
			}

			await _bookService.ImportBooksFromADatasheetAsync
				(
					new ImportBooksRequest
					{
						BookDatasheet = bookDatasheet
					}
				);

			return Ok();
		}

		[HttpGet]
		public async Task<IEnumerable<BookView>> GetAvailableBooksAsync()
		{
			return await Task.FromResult(new List<BookView>());
		}

		#endregion
	}
}