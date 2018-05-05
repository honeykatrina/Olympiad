﻿using System;
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

        protected GeneralRepository(OlympiadContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T item = _context.Set<T>().Find(id);
            if (item != null)
                _context.Set<T>().Remove(item);
        }
    }
}