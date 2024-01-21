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
    public class CustService:Service<Customer>,ICustomerService
    {
        IRepository<Customer> _repository;
        //ICustomerRepository _customer;
        public CustService(IRepository<Customer> repository):base(repository) 
        {
            _repository = repository;
           // _customer = customer;
        }
    }
}
