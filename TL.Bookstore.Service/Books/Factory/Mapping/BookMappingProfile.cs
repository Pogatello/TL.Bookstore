using AutoMapper;
using TL.Bookstore.Messaging.Books;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Service.Books.Factory.Mapping
{
	public class BookMappingProfile : Profile
	{
		public BookMappingProfile()
		{
			#region To Model

			CreateMap<BookDatasheetDto, Book>();

			#endregion

			#region ToView

			#endregion
		}
	}
}
