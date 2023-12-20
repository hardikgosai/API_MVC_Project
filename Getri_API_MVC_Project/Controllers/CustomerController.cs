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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Customer customer = new Customer();
            HttpResponseMessage response = await _client.GetAsync("api/CustomerAPI/GetCustomerById?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            string url = "api/CustomerAPI/CreateCustomer";
            if(ModelState.IsValid)
            {
                var response = await _client.PostAsJsonAsync(url, customer);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Unable to insert record");
                }
            }
           
            return View(customer);
        }
    }
}
