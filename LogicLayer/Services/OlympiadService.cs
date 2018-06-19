using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System.Collections.Generic;

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
                OlympiadName = item.OlympiadName,
                OlympiadLevel = item.OlympiadLevel,
                OlympiadStartDate=item.OlympiadStartDate,
                OlympiadEndDate=item.OlympiadEndDate,
                OlympiadDirection=item.OlympiadDirection,
                OlympiadType=item.OlympiadType,
                UniversityID=item.UniversityID
            };

            _database.Olympiads.Create(olympiad);
            _database.Save();
        }

        public void UpdateItem(OlympiadDTO item)
        {
            Olympiad olympiad = new Olympiad
            {
                OlympiadID = item.OlympiadID,
                OlympiadName = item.OlympiadName,
                OlympiadLevel = item.OlympiadLevel,
                OlympiadStartDate = item.OlympiadStartDate,
                OlympiadEndDate = item.OlympiadEndDate,
                OlympiadDirection = item.OlympiadDirection,
                OlympiadType = item.OlympiadType,
                UniversityID = item.UniversityID
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
            Olympiad item = _database.Olympiads.Get(id);
            return new OlympiadDTO
            {
                OlympiadID = item.OlympiadID,
                OlympiadName = item.OlympiadName,
                OlympiadLevel = item.OlympiadLevel,
                OlympiadStartDate = item.OlympiadStartDate,
                OlympiadEndDate = item.OlympiadEndDate,
                OlympiadDirection = item.OlympiadDirection,
                OlympiadType = item.OlympiadType,
                UniversityID = item.UniversityID
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