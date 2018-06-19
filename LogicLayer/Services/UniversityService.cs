using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using System.Collections.Generic;

namespace LogicLayer.Services
{
    public class UniversityService: IService<UniversityDTO>
    {
        private IUnitOfWork _database { get; set; }

        public UniversityService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(UniversityDTO item)
        {
            University university = new University
            {
                UniversityID = item.UniversityID,
                UniversityName = item.UniversityName,
                City = item.City,
                Country = item.Country

            };

            _database.Universities.Create(university);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            University university = new University() { UniversityID = id };
            _database.Universities.Delete(university.UniversityID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public UniversityDTO GetItem(int? id)
        {
            University university = _database.Universities.Get(id);
            //return Mapper.Map<Student, StudentDTO>(student);
            return new UniversityDTO
            {
                UniversityID = university.UniversityID,
                UniversityName = university.UniversityName,
                City = university.City,
                Country = university.Country
            };
        }

        public IEnumerable<UniversityDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<University>, List<UniversityDTO>>(_database.Universities.GetAll());
        }

        public void UpdateItem(UniversityDTO item)
        {
            University university = new University
            {
                UniversityID = item.UniversityID,
                UniversityName = item.UniversityName,
                City = item.City,
                Country = item.Country

            };

            _database.Universities.Update(university);
            _database.Save();
        }
    }
}