using CoreCustomer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void AddCustomer(Customer customer);
    }
}
