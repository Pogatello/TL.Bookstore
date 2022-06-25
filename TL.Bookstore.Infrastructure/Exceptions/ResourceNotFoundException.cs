namespace TL.Bookstore.Infrastructure
{
	public class ResourceNotFoundException : Exception
	{
		public ResourceNotFoundException() 
			: base("Traženi resurs nije pronađen.")
		{
		}
	}
}
