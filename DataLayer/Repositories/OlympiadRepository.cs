using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class OlympiadRepository: IRepository<Olympiad>
    {
        private OlympiadContext _context;
        public OlympiadRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<Olympiad> GetAll()
        {
            return _context.Olympiads;
        }

        public void Create(Olympiad item)
        {
            _context.Olympiads.Add(item);
        }

        public Olympiad Get(int? id)
        {
            return _context.Olympiads.Find(id);
        }

        public void Delete(int id)
        {
            Olympiad item = _context.Olympiads.Find(id);
            if (item != null)
                _context.Olympiads.Remove(item);
        }

        public void Update(Olympiad item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}