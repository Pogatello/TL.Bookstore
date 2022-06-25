namespace TL.Bookstore.Infrastructure.Helpers
{
	public static class CollectionExteension
	{
		public static bool HasElements<T>(this IEnumerable<T> input)
		{
			return input != null && input.Any();
		}
	}
}
