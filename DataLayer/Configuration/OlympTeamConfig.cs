using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class OlympTeamConfig : EntityTypeConfiguration<OlympiadTeam>
    {
        public OlympTeamConfig()
        {
            HasKey(x => new { x.OlympiadID, x.TeamID });
            ToTable("OlympiadTeams");

            HasRequired(x => x.Olympiad)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.OlympiadID);
            
            HasRequired(x => x.Team)
                .WithMany(x => x.Olympiads)
                .HasForeignKey(x => x.TeamID);

            HasRequired(x => x.Instructor)
                .WithMany(x => x.InstructorTeams)
                .HasForeignKey(x => x.InstructorID);
        }
    }
}