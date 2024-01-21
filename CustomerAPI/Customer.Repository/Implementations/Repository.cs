using CustomerRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRepository.Implementations
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected DbContext context;
        public Repository(DbContext _context)
        {
            context = _context;
        }

        public void AddCustomer(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            //context.SaveChanges();
        }

        public void DeleteCustomer(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            //context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAllCustomer()
        {
            IEnumerable<TEntity> entities= context.Set<TEntity>().ToList();
            return entities;
        }

        public TEntity GetCustomerById(int id)
        {
            TEntity entity=context.Set<TEntity>().Find(id);
            return entity;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateCustomer(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
