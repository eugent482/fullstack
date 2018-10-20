using BackEnd.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BackEnd.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private Model context;

        public ProductRepository()
        {
            context = new Model();
        }

        public void Create(Product item)
        {
            context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
                context.Products.Remove(product);
        }

        public Product GetItemById(int id)
        {
            return context.Products.Find(id);
        }

        public IQueryable<Product> GetItemQuery()
        {
            return context.Products.AsQueryable();
        }

        public IEnumerable<Product> GetItemList()
        {
            return context.Products;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Product item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int GetRows()
        {
            return context.Products.Count();
        }
    }
}