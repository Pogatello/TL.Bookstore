using AutoMapper;
using Microsoft.AspNetCore.Http;
using TL.Bookstore.Infrastructure.Helpers;
using TL.Bookstore.Messaging.Books;
using TL.Bookstore.Messaging.Books.Response;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Service.Books.Factory.Mapping;

namespace TL.Bookstore.Service.Books.Factory
{
	public class BookFactory : IBookFactory
	{
		#region Fields
		 
		private readonly IMapper _mapper;

		#endregion

		#region Constructors

		public BookFactory(IMapper mapper)
		{
			_mapper = mapper;
		}

		#endregion

		#region IBookFactory

		public IEnumerable<Book> CreateBooksFromADatasheet(IFormFile bookDatasheet)
		{
			var booksDto = CsvConverter.ConvertFileToRecords<BookDatasheetDto>(bookDatasheet);

			return booksDto.MapToModel(_mapper);
		}
		
		public ImportBooksResponse CreateImportBooksResponse(bool success = true)
		{
			return new ImportBooksResponse{ Success = success };
		}

		public GetAvailableBooksResponse CreateGetAvailableBooksResponse(IEnumerable<Book> books, bool success = true)
		{
			return new GetAvailableBooksResponse
			{
				Books = books.MapToView(_mapper),
				Success = success 
			};
		}

		#endregion
	}
}
