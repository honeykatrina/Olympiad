using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class OlympiadConfig : EntityTypeConfiguration<Olympiad>
    {
        public OlympiadConfig()
        {
            HasKey(x => x.OlympiadID);
            ToTable("Olympiads");
            HasRequired(x => x.University)
                .WithMany(x => x.Olympiads)
                .HasForeignKey(x => x.UniversityID);
        }
    }
}