using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DataLayer.Configuration
{
    public class ClientProfileConfig : EntityTypeConfiguration<ClientProfile>
    {
        public ClientProfileConfig()
        {
            HasKey(x => x.ClientId);
            ToTable("ClientProfiles");
        }
    }
}