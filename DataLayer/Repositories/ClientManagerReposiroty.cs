using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Models;
using DataLayer.Context;

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