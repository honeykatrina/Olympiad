using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    internal class UniversityConfig : EntityTypeConfiguration<University>
    {
        public UniversityConfig()
        {
            HasKey(x => new { x.UniversityID });
            ToTable("Universities");
        }
    }
}