using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TL.Bookstore.Infrastructure.Exceptions.Handlers
{
	public class ResourceNotFoundExceptionHandler : IExceptionHandler
	{
		public bool CanHandle(Exception e)
		{
			return e is ResourceNotFoundException;
		}

		public ObjectResult Handle(Exception e)
		{
			return new ObjectResult(new
			{
				Message = e.Message,
			})
			{
				StatusCode = (int)HttpStatusCode.NotFound
			};
		}
	}
}
