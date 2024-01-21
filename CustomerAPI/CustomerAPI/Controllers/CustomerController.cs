using CoreCustomer.Models;
using CustomerAPI.Module;
using CustomerService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = customerService.GetAllCustomer();
            return Ok(customers);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
        var cust=customerService.GetCustomerById(id);
            return Ok(cust);
        }
        [HttpPost]
        public IActionResult Add(CustomerModule cust)
        {
            Customer customer=new Customer()
            {
                Name = cust.Name,
                City = cust.City,
                Age = cust.Age,
            };
            customerService.AddCustomer(customer);
            return Ok(customer);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteById(int id)
        {
            var cust=customerService.GetCustomerById(id);
                customerService.DeleteCustomer(cust);
            return Ok(cust);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id,CustomerModule customer)
        {
            var cust = customerService.GetCustomerById(id);

            //Customer customer1 = new Customer()
            //{
            cust.Name = customer.Name;
            cust.City = customer.City;
            cust.Age = customer.Age;

            //};
        customerService.UpdateCustomer(cust);
            return Ok(cust);
        }
    }
}
