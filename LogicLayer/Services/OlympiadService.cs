using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer.Models;
using LogicLayer.Interfaces;
using DataLayer.Interfaces;
using AutoMapper;
using DataLayer.Models;

namespace LogicLayer.Services
{
    public class OlympiadService : IService<OlympiadDTO>
    {
        private IUnitOfWork _database { get; set; }

        public OlympiadService(IUnitOfWork uow)
        {
            _database = uow;
        }

        public void AddNewItem(OlympiadDTO item)
        {
            Olympiad olympiad = new Olympiad
            {
                OlympiadID = item.OlympiadID,
                OlympiadName = item.OlympiadName
            };

            _database.Olympiads.Create(olympiad);
            _database.Save();
        }

        public void UpdateItem(OlympiadDTO item)
        {
            Olympiad olympiad = new Olympiad
            {
                OlympiadID = item.OlympiadID,
                OlympiadName = item.OlympiadName
            };

            _database.Olympiads.Update(olympiad);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            Olympiad olympiadToDelete = new Olympiad() { OlympiadID = id };
            _database.Olympiads.Delete(olympiadToDelete.OlympiadID);
            _database.Save();
        }

        public OlympiadDTO GetItem(int? id)
        {
            Olympiad olympiad = _database.Olympiads.Get(id);
            return new OlympiadDTO
            {
                OlympiadID = olympiad.OlympiadID,
                OlympiadName = olympiad.OlympiadName
            };
        }

        public IEnumerable<OlympiadDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<Olympiad>, List<OlympiadDTO>>(_database.Olympiads.GetAll());
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}