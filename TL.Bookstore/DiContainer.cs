using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Contract.Books;
using TL.Bookstore.Infrastructure.Configuration;
using TL.Bookstore.Model.Books;
using TL.Bookstore.Model.Customers;
using TL.Bookstore.Repository;
using TL.Bookstore.Repository.Books;
using TL.Bookstore.Repository.Customers;
using TL.Bookstore.Service.Books;
using TL.Bookstore.Service.Books.Factory;
using TL.Bookstore.Service.Books.Factory.Mapping;

namespace TL.Bookstore.API
{
	public static class DiContainer
	{

		#region Public Methods

		public static void Configure(WebApplicationBuilder builder)
		{
			ConfigureServices(builder.Services);
			ConfigureRepositories(builder.Services, builder.Configuration);
			ConfigureDatabase(builder.Services, builder.Configuration);
			ConfigureMappingProfiles(builder.Services);
		}

		#endregion


		#region Private Methods

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IBookService, BookService>();
			services.AddTransient<IBookFactory, BookFactory>();
		}

		private static void ConfigureRepositories(IServiceCollection services, IConfiguration config)
		{
			services.AddTransient<IBookRepository, BookRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
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

		public static void ConfigureMappingProfiles(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new BookMappingProfile());
			});

			services.AddSingleton(mapperConfig.CreateMapper());
		}

		#endregion
	}
}
