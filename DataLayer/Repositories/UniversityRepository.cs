using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;
using DataLayer.Interfaces;
using System.Data.Entity;

namespace DataLayer.Repositories
{
    public class UniversityRepository: IRepository<University>
    {
        private OlympiadContext _context;
        public UniversityRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<University> GetAll()
        {
            return _context.Universities;
        }

        public void Create(University item)
        {
            _context.Universities.Add(item);
        }

        public University Get(int? id)
        {
            return _context.Universities.Find(id);
        }

        public void Delete(int id)
        {
            University item = _context.Universities.Find(id);
            if (item != null)
                _context.Universities.Remove(item);
        }

        public void Update(University item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}