using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class OlympStudConfig : EntityTypeConfiguration<OlympiadStudent>
    {
        public OlympStudConfig()
        {
            HasKey(x => new { x.OlympiadStudentID });
            ToTable("OlympiadStudents");

            HasRequired(x => x.Olympiad)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.OlympiadID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Student)
                .WithMany(x => x.Olympiads)
                .HasForeignKey(x => x.StudentID)
                .WillCascadeOnDelete(false);


            HasRequired(x => x.Instructor)
                .WithMany(x => x.InstructorStudents)
                .HasForeignKey(x => x.InstructorID)
                .WillCascadeOnDelete(false);

        }
    }
}