﻿namespace TL.Bookstore.Model.Books
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> GetAvailableBooksAsync();

		Task<Book> GetBookByISBNAsync(string isbn);

		Task<IEnumerable<Book>> GetBorrowedBooksAsync(string username);

		Task CreateBooksAsync(IEnumerable<Book> books);

		Task UpdateBookAsync(Book book);
	}
}