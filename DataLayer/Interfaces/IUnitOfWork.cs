using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Interfaces
{
    interface IUnitOfWork: IDisposable
    {
        IRepository<Department> Department { get; }
        IRepository<Instructor> Instructor { get; }
        IRepository<Olympiad> Olympiad { get; }
        IRepository<Student> Student { get; }
        IRepository<Team> Team { get; }
        IRepository<University> University { get; }
        void Save();
    }
}
