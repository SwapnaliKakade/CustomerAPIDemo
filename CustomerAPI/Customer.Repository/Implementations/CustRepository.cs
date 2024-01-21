using CoreCustomer.Models;
using CustomerRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository.Implementations
{
    public class CustRepository:Repository<Customer>,ICustomerRepository
    {
        AppDBContext dbcontext
        {
            get
            {
                return context as AppDBContext;
            }
        }
        public CustRepository(AppDBContext dbcon):base(dbcon) { }

    }
}
