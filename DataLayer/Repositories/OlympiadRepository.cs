using DataLayer.Context;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class OlympiadRepository: GeneralRepository<Olympiad>
    {
        public OlympiadRepository(OlympiadContext context)
            :base(context)
        {
        }
    }
}