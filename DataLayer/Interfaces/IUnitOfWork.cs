using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Identity;

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
        IRepository<OlympiadStudent> OlympiadStudents { get; }
        IRepository<OlympiadTeam> OlympiadTeams { get; }
        IRepository<StudentTeam> StudentTeams { get; }
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
        void Save();
    }
}
