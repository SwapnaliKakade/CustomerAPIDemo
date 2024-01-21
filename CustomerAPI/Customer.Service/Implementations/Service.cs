using CustomerRepository.Implementations;
using CustomerRepository.Interfaces;
using CustomerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Implementations
{
    public class Service<TEntity>:IService<TEntity> where TEntity : class
    {
        public IRepository<TEntity> repo;
        public Service(IRepository<TEntity> _repo) {
        repo = _repo;
        }

        public void AddCustomer(TEntity entity)
        {
            repo.AddCustomer(entity);
            repo.SaveChanges();
        }
        public void DeleteCustomer(TEntity entity)
        {
            repo.DeleteCustomer(entity);
                repo.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllCustomer()
        {
         //   repo.GetAllCustomer();
                return repo.GetAllCustomer();
        }

        public TEntity GetCustomerById(int id)
        {
            return repo.GetCustomerById(id);
        }

        public void SaveChanges()
        {
                repo.SaveChanges();
        }

        public void UpdateCustomer(TEntity entity)
        {
           repo.UpdateCustomer(entity);
            repo.SaveChanges();
        }
    }
}
