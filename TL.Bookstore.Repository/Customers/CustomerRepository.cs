using Microsoft.EntityFrameworkCore;
using TL.Bookstore.Model.Customers;

namespace TL.Bookstore.Repository.Customers
{
	public class CustomerRepository : ICustomerRepository
	{
		#region Fields

		private readonly BookstoreDbContext _dbContext;

		#endregion

		#region Constructors 

		public CustomerRepository(BookstoreDbContext context)
		{
			_dbContext = context;
		}

		#endregion

		#region ICustomerRepository

		public async Task<Customer> GetCustomerByUsernameAsync(string username)
		{
			return await _dbContext.Customers.SingleOrDefaultAsync(cust => cust.Username == username);
		}

		public async Task CreateCustomerAsync(Customer customer)
		{
			await _dbContext.Customers.AddAsync(customer);
			await _dbContext.SaveChangesAsync();
		}

		#endregion
	}
}
