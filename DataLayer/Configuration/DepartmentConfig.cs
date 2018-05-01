using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DataLayer.Models;

namespace DataLayer.Configuration
{
    internal class DepartmentConfig: EntityTypeConfiguration<Department>
    {
        public DepartmentConfig()
        {
            HasKey(x => x.DepartmentID);
            ToTable("Departments");
        }
    }
}