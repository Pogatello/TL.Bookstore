using TL.Bookstore.Infrastructure.Exceptions.Handlers;

namespace TL.Bookstore.Infrastructure.Exceptions.Factories
{
	public interface IExceptionHandlerFactory
	{
		public IExceptionHandler SelectHandler(Exception e);
	}
}
