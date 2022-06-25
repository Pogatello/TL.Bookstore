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


		[HttpGet("GetAvailableBooks")]
		public async Task<ActionResult<IEnumerable<BookView>>> GetAvailableBooksAsync(int? pageNumber, int? itemsPerPage)
		{
			var response = await _bookService.GetAvailableBooksAsync(
				new GetAvailableBooksRequest 
				{ 
					PageNumber = pageNumber ?? default,
					ItemsPerPage = itemsPerPage ?? default
				});

			return Ok(response.Books);
		}

		[HttpGet("GetBookByIsbn/{isbn}")]
		public async Task<ActionResult<BookView>> GetBookByIsbnAsync([FromRoute] string isbn)
		{
			var response = await _bookService.GetBookByIsbnAsync(
				new GetBookRequest
				{
					Isbn = isbn
				});

			return Ok(response.Book);
		}

		[HttpGet("GetBorrowedBooks/{username}")]
		public async Task<ActionResult<IEnumerable<BookView>>> GetBorrowedBooksAsync([FromRoute] string username)
		{
			var response = await _bookService.GetBorrowedBooksAsync(
				new GetBorrowedBooksRequest
				{
					Username = username
				});

			return Ok(response.Books);
		}

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

		#endregion
	}
}