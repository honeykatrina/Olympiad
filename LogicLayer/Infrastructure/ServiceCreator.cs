using DataLayer.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicLayer.Infrastructure
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new EFUnitOfWork(connection));
        }
    }
}