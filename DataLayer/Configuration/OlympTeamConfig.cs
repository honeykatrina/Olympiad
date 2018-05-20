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
            HasKey(x => new { x.OlympiadTeamID });
            ToTable("OlympiadTeams");

            HasRequired(x => x.Olympiad)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.OlympiadID)
                .WillCascadeOnDelete(false);
            
            HasRequired(x => x.Team)
                .WithMany(x => x.Olympiads)
                .HasForeignKey(x => x.TeamID)
                .WillCascadeOnDelete(true);

            HasRequired(x => x.Instructor)
                .WithMany(x => x.InstructorTeams)
                .HasForeignKey(x => x.InstructorID)
                .WillCascadeOnDelete(false);
        }
    }
}