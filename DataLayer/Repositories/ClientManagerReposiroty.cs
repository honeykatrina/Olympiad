using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class ClientManagerReposiroty : IClientManager
    {
        private OlympiadContext _context;
        public ClientManagerReposiroty(OlympiadContext context)
        {
            _context = context;
        }

        public void Create(ClientProfile item)
        {
            _context.ClientProfiles.Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}