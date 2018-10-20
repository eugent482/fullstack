using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Repository
{
    public interface IRepository<T> : IDisposable
    {
       IEnumerable<T> GetItemList(); 
        T GetItemById(int id);
        IQueryable<T> GetItemQuery();
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}