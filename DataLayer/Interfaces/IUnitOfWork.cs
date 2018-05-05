using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Department> Departments { get; }
        IRepository<Instructor> Instructors { get; }
        IRepository<Olympiad> Olympiads { get; }
        IRepository<Student> Students { get; }
        IRepository<Team> Teams { get; }
        IRepository<University> Universities { get; }
        void Save();
    }
}
