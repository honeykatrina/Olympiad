using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class StudentTeamConfig : EntityTypeConfiguration<StudentTeam>
    {
        public StudentTeamConfig()
        {
            HasKey(x => new { x.StudentTeamID});
            ToTable("StudentTeams");

            HasRequired(x => x.Student)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.StudentID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Team)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.TeamID)
                .WillCascadeOnDelete(false);
        }
    }
}