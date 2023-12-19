using Getri_API_MVC_Project.EntityFramework;
using Getri_API_MVC_Project.Models;

namespace Getri_API_MVC_Project.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext customerDbContext;

        public CustomerRepository(CustomerDbContext _customerDbContext) 
        {
            customerDbContext = _customerDbContext;
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = customerDbContext.Customers.Find(customerId);
            if (customer == null)
            {
                return false;
            }
            else
            {
                customerDbContext.Customers.Remove(customer);
                customerDbContext.SaveChanges();
                return true;
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = customerDbContext.Customers.Find(customerId);
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerDbContext.Customers.ToList();
        }

        public Customer InsertCustomer(Customer customer)
        {
            customerDbContext.Customers.Add(customer);
            customerDbContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var customerExist = customerDbContext.Customers.Find(customer.CustomerId);
            if (customerExist == null)
            {
                throw new ArgumentNullException("Customer Not Found");
            }
            else
            {
                customerExist.CustomerName = customer.CustomerName;
                customerExist.CustomerEmail = customer.CustomerEmail;
                customerExist.CustomerAge = customer.CustomerAge;
                customerExist.CustomerAddress = customer.CustomerAddress;
                customerExist.CustomerPhone = customer.CustomerPhone;
                customerDbContext.SaveChanges();
                return customerExist;
            }
        }
    }
}
