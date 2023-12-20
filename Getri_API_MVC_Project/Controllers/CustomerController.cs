using Getri_API_MVC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Getri_API_MVC_Project.Controllers
{
    public class CustomerController : Controller
    {
        HttpClient _client;
        IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            string apiAddress = _configuration["ApiAddress"];
            Uri baseAddress = new Uri(apiAddress);
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = new List<Customer>();
            HttpResponseMessage response = await _client.GetAsync("api/CustomerAPI/AllCustomerList");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);
            }
            return View(customers);
        }
    }
}
