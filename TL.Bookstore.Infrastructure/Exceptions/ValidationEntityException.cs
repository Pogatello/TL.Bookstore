namespace TL.Bookstore.Infrastructure.Exceptions
{
	public class ValidationEntityException : Exception
	{
		public ValidationEntityException(string message) 
			:base(message)
		{

		}
	}
}
