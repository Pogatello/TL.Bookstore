using Microsoft.AspNetCore.Mvc;

namespace TL.Bookstore.Infrastructure.Exceptions.Handlers
{
	public interface IExceptionHandler
	{
		public bool CanHandle(Exception e);

		public ObjectResult Handle(Exception e);
	}
}
