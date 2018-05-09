using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using LogicLayer.Models;
using LogicLayer.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace LogicLayer.Services
{
    public class DepartmentService : IService<DepartmentDTO>
    {
        private IUnitOfWork _database { get; set; }

        public DepartmentService(IUnitOfWork uow)
        {
            _database = uow;
        }
        public void AddNewItem(DepartmentDTO item)
        {
            Department department = new Department()
            {
                DepartmentID = item.DepartmentID,
                DepartmentName = item.DepartmentName
            };

            _database.Departments.Create(department);
            _database.Save();
        }

        public void DeleteItem(int id)
        {
            Department departmentToDelete = new Department() { DepartmentID = id };
            _database.Departments.Delete(departmentToDelete.DepartmentID);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public DepartmentDTO GetItem(int? id)
        {
            Department department = _database.Departments.Get(id);
            //return Mapper.Map<Department, DepartmentDTO>(Department);
            return new DepartmentDTO
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName
            };
        }

        public IEnumerable<DepartmentDTO> GetItems()
        {
            return Mapper.Map<IEnumerable<Department>, List<DepartmentDTO>>(_database.Departments.GetAll());
        }

        public void UpdateItem(DepartmentDTO item) //???
        {
            Department department = _database.Departments.Get(item.DepartmentID);
            _database.Departments.Update(department);
        }
    }
}