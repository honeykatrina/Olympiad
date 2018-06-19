using DataLayer.Context;
using DataLayer.Identity;
using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private OlympiadContext _context;
        private DepartmentRepository _departmentRepository;
        private InstructorRepository _instructorRepository;
        private OlympiadRepository _olympiadRepository;
        private StudentRepository _studentRepository;
        private TeamRepository _teamRepository;
        private UniversityRepository _universityRepository;
        private OlympiadStudentRepository _olympiadStudentsRepository;
        private OlympiadTeamRepository _olympiadTeamsRepository;
        private StudentTeamRepository _studentTeamsRepository;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IClientManager _clientManager;

        public EFUnitOfWork(string connectionString)
        {
            _context = new OlympiadContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
            _clientManager = new ClientManagerReposiroty(_context);
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager; }
        }

        public IClientManager ClientManager
        {
            get { return _clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager; }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IRepository<Department> Departments
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_context);
                return _departmentRepository;
            } 
        }

        public IRepository<Instructor> Instructors
        {
            get
            {
                if (_instructorRepository == null)
                    _instructorRepository = new InstructorRepository(_context);
                return _instructorRepository;
            } 
        }

        public IRepository<Olympiad> Olympiads
        {
            get
            {
                if (_olympiadRepository == null)
                    _olympiadRepository = new OlympiadRepository(_context);
                return _olympiadRepository;
            } 
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            } 
        }

        public IRepository<Team> Teams
        {
            get
            {
                if (_teamRepository == null)
                    _teamRepository = new TeamRepository(_context);
                return _teamRepository;
            } 
        }

        public IRepository<University> Universities
        {
            get
            {
                if (_universityRepository == null)
                    _universityRepository = new UniversityRepository(_context);
                return _universityRepository;
            } 
        }

        public IRepository<OlympiadStudent> OlympiadStudents
        {
            get
            {
                if (_olympiadStudentsRepository == null)
                    _olympiadStudentsRepository = new OlympiadStudentRepository(_context);
                return _olympiadStudentsRepository;
            }
        }

        public IRepository<OlympiadTeam> OlympiadTeams
        {
            get
            {
                if (_olympiadTeamsRepository == null)
                    _olympiadTeamsRepository = new OlympiadTeamRepository(_context);
                return _olympiadTeamsRepository;
            }
        }

        public IRepository<StudentTeam> StudentTeams
        {
            get
            {
                if (_studentTeamsRepository == null)
                    _studentTeamsRepository = new StudentTeamRepository(_context);
                return _studentTeamsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}