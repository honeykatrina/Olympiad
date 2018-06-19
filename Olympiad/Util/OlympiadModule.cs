using LogicLayer.Interfaces;
using LogicLayer.Models;
using LogicLayer.Services;
using Ninject.Modules;

namespace Olympiad.Util
{
    // Dependency matching class
    public class OlympiadModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<StudentDTO>>().To<StudentService>();
            Bind<IService<DepartmentDTO>>().To<DepartmentService>();
            Bind<IService<TeamDTO>>().To<TeamService>();
            Bind<IService<InstructorDTO>>().To<InstructorService>();
            Bind<IService<OlympiadDTO>>().To<OlympiadService>();
            Bind<IService<UniversityDTO>>().To<UniversityService>();
            Bind<IService<OlympiadStudentDTO>>().To<OlympiadStudentService>();
            Bind<IService<OlympiadTeamDTO>>().To<OlympiadTeamService>();
            Bind<IService<StudentTeamDTO>>().To<StudentTeamService>();
            Bind<IReportService>().To<ReportService>();
        }
    }
}