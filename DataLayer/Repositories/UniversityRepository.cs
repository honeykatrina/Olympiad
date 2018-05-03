using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class UniversityRepository: GeneralRepository<University>
    {
        public UniversityRepository(OlympiadContext context)
            :base(context)
        {
        }
    }
}