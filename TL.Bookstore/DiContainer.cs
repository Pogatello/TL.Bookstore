using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Contract.Books;
using TL.Bookstore.Infrastructure.Configuration;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Repository;
using TL.Bookstore.Repository.Books;
using TL.Bookstore.Service.Books;

namespace TL.Bookstore.API
{
	public static class DiContainer
	{

		#region Public Methods

		public static void Configure(WebApplicationBuilder builder)
		{
			ConfigureServices(builder.Services);
			ConfigureRepositories(builder.Services, builder.Configuration);
		}

		#endregion


		#region Private Methods

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IBookService, BookService>();
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration config)
		{
			services.AddTransient<IBookRepository, BookRepository>();

			ConfigureDatabase(services, config);
		}

		private static void ConfigureDatabase(IServiceCollection services, IConfiguration config)
		{
			var databaseConfig = config.GetSection(nameof(DatabaseConfiguration)).Get<DatabaseConfiguration>();

			services.AddDbContext<BookstoreDbContext>(
				(options) => options.UseSqlServer(databaseConfig.BookstoreConnectionString)
				,
				ServiceLifetime.Scoped
			);
		}

		#endregion
	}
}
