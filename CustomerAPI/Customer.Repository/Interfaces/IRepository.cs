using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllCustomer();
        void AddCustomer(TEntity entity);
        void UpdateCustomer(TEntity entity);
        void DeleteCustomer(TEntity entity);
        TEntity GetCustomerById(int id);
        void SaveChanges();
    }
}
