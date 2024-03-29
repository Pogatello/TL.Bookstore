﻿using Microsoft.AspNetCore.Http;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Service.Books.Factory
{
	public interface IBookFactory
	{
		IEnumerable<Book> CreateBooksFromADatasheet(IFormFile bookDatasheet);

		ImportBooksResponse CreateImportBooksResponse(bool success = true);

		GetAvailableBooksResponse CreateGetAvailableBooksResponse(IEnumerable<Book> books, bool success = true);

		GetBookResponse CreateGetBookResponse(Book book, bool success = true);

		GetBorrowedBooksResponse CreateGetBorrowedBooksResponse(IEnumerable<Book> books, bool success = true);

		BorrowBookResponse CreateBorrowBookResponse(Book book, bool success = true);
	}
}
