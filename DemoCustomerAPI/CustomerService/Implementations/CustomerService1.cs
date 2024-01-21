using CoreCustomer.Models;
using CustomerRepository.Interfaces;
using CustomerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Implementations
{
    public class CustomerService1 : ICustomerService
    {
        ICustomerRepository repo;
        public CustomerService1(ICustomerRepository repo)
        {
            this.repo = repo;
        }
        public void AddCustomer(Customer customer)
        {
            repo.AddCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            repo.DeleteCustomer(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return repo.GetAll();
        }

        public Customer GetById(int id)
        {
            return repo.GetById(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            repo.UpdateCustomer(customer);
        }
    }
}
