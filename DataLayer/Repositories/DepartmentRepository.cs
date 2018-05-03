using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class DepartmentRepository: GeneralRepository<Department>
    {
        public DepartmentRepository(OlympiadContext context)
            :base(context)
        {
        }
    }
}