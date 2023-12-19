using Getri_API_MVC_Project.Models;

namespace Getri_API_MVC_Project.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int customerId);
        Customer InsertCustomer(Customer customer);
        bool DeleteCustomer(int customerId);
        Customer UpdateCustomer(Customer customer);
    }
}
