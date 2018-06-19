using DataLayer.Interfaces;
using DataLayer.Repositories;
using Ninject.Modules;

namespace LogicLayer.Services
{
    public class ServiceModule: NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}