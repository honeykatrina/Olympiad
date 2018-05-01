using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class TeamConfig : EntityTypeConfiguration<Team>
    {
        public TeamConfig()
        {
            HasKey(x => new { x.TeamID });
            ToTable("Teams");
        }
    }
}