using CoreCustomer.Models;
using CustomerRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository.Implementations
{
    public class CustomerRepository1:ICustomerRepository
    {
        AppDBContext dbContext;
        public CustomerRepository1(AppDBContext db) {
        dbContext = db;
        }

        public void AddCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return dbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return dbContext.Customers.Find(id);
        }

        public void UpdateCustomer(Customer customer)
        {
            dbContext.Customers.Update(customer);
            dbContext.SaveChanges();
        }
    }
}
