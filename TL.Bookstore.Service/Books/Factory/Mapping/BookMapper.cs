using AutoMapper;
using TL.Bookstore.Messaging.Books;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Service.Books.Factory.Mapping
{
	public static class BookMapper
	{
		public static IEnumerable<Book> MapToModel(this IEnumerable<BookDatasheetDto> views, IMapper mapper)
		{
			return mapper.Map<IEnumerable<Book>>(views);
		}
	}
}
