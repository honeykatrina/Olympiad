using AutoMapper;
using DataLayer.Models;
using LogicLayer.Models;
using LogicLayer.Services;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Olympiad.Models;
using Olympiad.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            });
        }
    }
}
