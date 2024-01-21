using CoreCustomer.Models;
using CustomerService.Interfaces;
using DemoCustomerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService customerService;
        public CustomerController(ICustomerService service) {
        customerService = service;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var cust = customerService.GetAll();
            return Ok(cust);
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomersById(int id) 
        { 
            if(ModelState.IsValid)
            {
                try
                {
                    var cust = customerService.GetById(id);
                    return Ok(cust);
                }
                catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            { 
                return BadRequest("Invalid ID"); 
            }
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerModel cust)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Customer customer = new Customer()
                    {
                        Name = cust.Name,
                        City = cust.City,
                        Age = cust.Age,
                    };
                    customerService.AddCustomer(customer);
                    return Created("Create", customer);
                }
                catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            if (id < 0)
                return BadRequest("Invalid Id");
            else
            {
                Customer cust=customerService.GetById(id);
                if(cust!=null)
                {
                    customerService.DeleteCustomer(cust);
                    return Ok(cust);
                }
                else
                {
                    return NotFound("Customer not found");
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer(int id,CustomerModel customer)
        {
            if(ModelState.IsValid)
            {
                try
                {

                    Customer cust = customerService.GetById(id);

                    cust.Name = customer.Name;
                    cust.City = customer.City;
                    cust.Age = customer.Age;
                    
                    customerService.UpdateCustomer(cust);
                    return Ok(cust);
                }
                catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            else
            {
                return BadRequest("Invalid Input");
            }
        }
    }
}
