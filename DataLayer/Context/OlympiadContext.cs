using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using DataLayer.Models;
using System.Data.Entity;
using DataLayer.Configuration;

namespace DataLayer.Context
{
    public class OlympiadContext: IdentityDbContext<ApplicationUser>
    {
        static OlympiadContext()
        {
            Database.SetInitializer<OlympiadContext>(new ContextInitializer());
        }

        public OlympiadContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<OlympiadStudent> OlympiadStudents { get; set; }
        public DbSet<OlympiadTeam> OlympiadTeams { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentTeam> StudentTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfig());
            modelBuilder.Configurations.Add(new InstructorConfig());
            modelBuilder.Configurations.Add(new OlympiadConfig());
            modelBuilder.Configurations.Add(new OlympStudConfig());
            modelBuilder.Configurations.Add(new OlympTeamConfig());
            modelBuilder.Configurations.Add(new StudentConfig());
            modelBuilder.Configurations.Add(new StudentTeamConfig());
            modelBuilder.Configurations.Add(new TeamConfig());
            modelBuilder.Configurations.Add(new UniversityConfig());

        }
}
}