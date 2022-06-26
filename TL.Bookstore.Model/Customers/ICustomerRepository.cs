namespace TL.Bookstore.Model.Customers
{
	public interface ICustomerRepository
	{

		Task<Customer> GetCustomerByUsernameAsync(string username);

		Task CreateCustomerAsync(Customer customer);
	}
}
