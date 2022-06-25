using AutoMapper;
using TL.Bookstore.Messaging.Books;
using TL.Bookstore.Messaging.Books.View;
using TL.Bookstore.Model.Books;

namespace TL.Bookstore.Service.Books.Factory.Mapping
{
	public class BookMappingProfile : Profile
	{
		public BookMappingProfile()
		{
			#region To Model

			CreateMap<BookDatasheetDto, Book>()
				.ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.bookID))
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.title))
				.ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.authors))
				.ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.average_rating))
				.ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.isbn))
				.ForMember(dest => dest.Isbn13, opt => opt.MapFrom(src => src.isbn13))
				.ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.language_code))
				.ForMember(dest => dest.PageNumbers, opt => opt.MapFrom(src => src.num_pages))
				.ForMember(dest => dest.RatingsCount, opt => opt.MapFrom(src => src.ratings_count))
				.ForMember(dest => dest.TextReviewsCount, opt => opt.MapFrom(src => src.text_reviews_count))
				.ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.publication_date))
				.ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.publisher));

			#endregion

			#region ToView

			CreateMap<Book, BookView>();

			#endregion
		}
	}
}
