﻿using AutoMapper;
using DataLayer.Models;
using LogicLayer.Models;
using LogicLayer.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Olympiad.Models;
using Olympiad.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Olympiad
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Dependency injection
            NinjectModule olympiadModule = new OlympiadModule();
            NinjectModule serviceModule = new ServiceModule("DbConnection");
            var kernel = new StandardKernel(olympiadModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            kernel.Unbind<ModelValidatorProvider>(); // ?

            // Create mappers
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Student, StudentDTO>();
                cfg.CreateMap<StudentViewModel, StudentDTO>();
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentViewModel, DepartmentDTO>();
                cfg.CreateMap<Instructor, InstructorDTO>();
                cfg.CreateMap<InstructorViewModel, InstructorDTO>();
                cfg.CreateMap<University, UniversityDTO>();
                cfg.CreateMap<UniversityViewModel, UniversityDTO>();
                cfg.CreateMap<Team, TeamDTO>();
                cfg.CreateMap<TeamViewModel, TeamDTO>();
                cfg.CreateMap<StudentTeam, StudentTeamDTO>();
                cfg.CreateMap<StudentTeamViewModel, StudentTeamDTO>();
                cfg.CreateMap<OlympiadTeam, OlympiadTeamDTO>();
                cfg.CreateMap<OlympiadTeamViewModel, OlympiadTeamDTO>();
                cfg.CreateMap<OlympiadStudent, OlympiadStudentDTO>();
                cfg.CreateMap<OlympiadStudentViewModel, OlympiadStudentDTO>();
            });
        }
    }
}
