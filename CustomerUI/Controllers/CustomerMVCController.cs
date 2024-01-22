using CustomerUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CustomerUI.Controllers
{
    public class CustomerMVCController : Controller
    {
        HttpClient client;
        IConfiguration configuration;
        string baseaddress;
        public CustomerMVCController(IConfiguration configuration)
        {
            this.client = new HttpClient();
            
            baseaddress = configuration["APIBaseAddress"];
            this.client.BaseAddress = new Uri(baseaddress);
        }
        public IActionResult GetAllCustomerMVC()
        {
            string result = client.GetStringAsync(baseaddress + "/GetAllCustomers").Result;
            List<CustomerMVCModel> customer = JsonSerializer.Deserialize<List<CustomerMVCModel>>(result);
            return View(customer);
        }
    }
}
