using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
