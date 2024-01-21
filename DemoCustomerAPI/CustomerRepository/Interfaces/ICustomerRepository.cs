using CoreCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void AddCustomer(Customer customer);
    }
}
