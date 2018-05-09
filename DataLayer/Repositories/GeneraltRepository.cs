using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Interfaces;
using DataLayer.Context;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class GeneralRepository<T>: IRepository<T> where T:class, new()
    {
        private OlympiadContext _context;

        public GeneralRepository()
        {
            
        }
        protected GeneralRepository(OlympiadContext context)
        {
            _context = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T Get(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public virtual void Create(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            T item = _context.Set<T>().Find(id);
            if (item != null)
                _context.Set<T>().Remove(item);
        }
    }
}