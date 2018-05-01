using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class InstructorConfig : EntityTypeConfiguration<Instructor>
    {
        public InstructorConfig()
        {
            HasKey(x => x.InstructorID);
            ToTable("Instructors");
            HasRequired(x => x.Department)
                .WithMany(x => x.Instructors)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}