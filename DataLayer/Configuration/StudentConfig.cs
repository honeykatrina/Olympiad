using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class StudentConfig : EntityTypeConfiguration<Student>
    {
        public StudentConfig()
        {
            HasKey(x => x.StudentID);
            ToTable("Students");
            HasRequired(x => x.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.DepartmentId)
                .WillCascadeOnDelete(false);
        }
    }
}