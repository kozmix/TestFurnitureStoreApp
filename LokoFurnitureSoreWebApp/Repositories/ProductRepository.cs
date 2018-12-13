using FurnitureStoreWebApp.Data;
using FurnitureStoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebApp.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private FurnitureStoreSqliteDbContext _context;

        public ProductRepository(FurnitureStoreSqliteDbContext context)
        {
            _context = context;
        }

        public bool EntityExists(string entityName)
        {
            return _context.Products.Any(c => c.Name == entityName);
        }

        public IEnumerable<Product> GetEntities()
        {
            return _context.Products.OrderBy(c => c.Name).ToList();
        }

        public Product GetEntity(int entityId)
        {
            return _context.Products.Where(p => p.Id == entityId).FirstOrDefault();
        }

        public Product GetEntity(string entityName)
        {
            return _context.Products.Where(p => p.Name == entityName).FirstOrDefault();
        }

        public void AddEntity(Product entity)
        {
            _context.Products.Add(entity);
        }

        public void DeleteEntity(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public void UpdateEntity(Product entity)
        {
            _context.Products.Update(entity);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
