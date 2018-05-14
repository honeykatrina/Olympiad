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
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void Update(Olympiad item)
        {
            Olympiad dbOlympiad = _context.Olympiads.Find(item.OlympiadID);
            if (dbOlympiad != null)
            {
                dbOlympiad.OlympiadName = item.OlympiadName;
                dbOlympiad.OlympiadLevel = item.OlympiadLevel;
                dbOlympiad.OlympiadStartDate = item.OlympiadStartDate;
                dbOlympiad.OlympiadEndDate = item.OlympiadEndDate;
                dbOlympiad.OlympiadDirection = item.OlympiadDirection;
                dbOlympiad.OlympiadType = item.OlympiadType;
                dbOlympiad.UniversityID = item.UniversityID;
            }
            _context.SaveChanges();
        }
    }
}