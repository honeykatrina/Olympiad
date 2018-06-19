using DataLayer.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Services;

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