using LogicLayer.Interfaces;
using LogicLayer.Models;
using LogicLayer.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiad.Util
{
    // Dependency matching class
    public class OlympiadModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<StudentDTO>>().To<StudentService>();
        }
    }
}