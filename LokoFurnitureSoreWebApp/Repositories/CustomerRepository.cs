using FurnitureStoreWebApp.Data;
using FurnitureStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebApp.Repositories
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private FurnitureStoreSqliteDbContext _context;

        public CustomerRepository(FurnitureStoreSqliteDbContext context)
        {
            _context = context;
        }

        public bool EntityExists(string entityName)
        {
            return _context.Customers.Any(c => c.Name == entityName);
        }

        public IEnumerable<Customer> GetEntities()
        {
            return _context.Customers.OrderBy(c => c.Name).ToList();
        }

        public Customer GetEntity(int entityId)
        {
            return _context.Customers.Where(c => c.Id == entityId).FirstOrDefault();
        }

        public Customer GetEntity(string entityName)
        {
            return _context.Customers.Where(c => c.Name == entityName).FirstOrDefault();
        }

        public void AddEntity(Customer entity)
        {
            _context.Customers.Add(entity);
        }

        public void DeleteEntity(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public void UpdateEntity(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
