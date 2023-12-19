using Getri_API_MVC_Project.Models;
using Getri_API_MVC_Project.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Getri_API_MVC_Project.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerAPIController(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        [HttpGet("AllCustomerList")]
        public IActionResult GetCustomers()
        {
            var customers = customerRepository.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("GetCustomerById")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = customerRepository.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost("CreateCustomer")]
        public IActionResult InsertCustomer([FromBody] Customer customer)
        {
            var customerNew = customerRepository.InsertCustomer(customer);
            return Ok(customerNew);
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            var customerNew = customerRepository.UpdateCustomer(customer);
            return Ok(customerNew);
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customerRepository.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
