using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public class DepartmentRepository: IRepository<Department>
    {
        private OlympiadContext _context;
        public DepartmentRepository(OlympiadContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments;
        }

        public void Create(Department item)
        {
            _context.Departments.Add(item);
            _context.SaveChanges();
        }

        public Department Get(int? id)
        {
            return _context.Departments.Find(id);
        }

        public void Delete(int id)
        {
            Department item = _context.Departments.Find(id);
            if (item != null)
                _context.Departments.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Department item)
        {
            Department dbDepartment = _context.Departments.Find(item.DepartmentID);
            if (dbDepartment != null)
            {
                dbDepartment.DepartmentName = item.DepartmentName;
            }
            _context.SaveChanges();
        }
    }
}