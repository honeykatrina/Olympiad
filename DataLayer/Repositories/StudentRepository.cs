using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class StudentRepository: GeneralRepository<Student>
    {
        public StudentRepository(OlympiadContext context)
            :base(context)
        {
        }
    }
}