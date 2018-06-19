using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class DepartmentController : Controller
    {
        private IService<DepartmentDTO> _depatrmentService;

        public DepartmentController(IService<DepartmentDTO> depatrmentService)
        {
            _depatrmentService = depatrmentService;
        }
        //
        // GET: /Department/
        public ActionResult Index()
        {
            IEnumerable<DepartmentDTO> departmentDtos = _depatrmentService.GetItems();
            var departments = Mapper.Map<IEnumerable<DepartmentDTO>, List<DepartmentViewModel>>(departmentDtos);
            return View(departments);
        }

        //
        // GET: /Department/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentViewModel department)
        {
            _depatrmentService.AddNewItem(new DepartmentDTO()
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName
            });

            return RedirectToAction("Index");
        }

        //
        // GET: /Department/Edit/5
        public ActionResult Edit(int id)
        {
            DepartmentDTO departmentDto = _depatrmentService.GetItem(id);
            var department = Mapper.Map<DepartmentDTO, DepartmentViewModel>(departmentDto);
            return View(department);
        }

        //
        // POST: /Department/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartmentViewModel department)
        {
            _depatrmentService.UpdateItem(new DepartmentDTO()
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName
            });
            return RedirectToAction("Index");
        }

        //
        // GET: /Department/Delete/5
        public ActionResult Delete(int? id)
        {
            DepartmentDTO departmentDto = _depatrmentService.GetItem(id);
            var department = Mapper.Map<DepartmentDTO, DepartmentViewModel>(departmentDto);
            return View(department);
        }

        //
        // POST: /Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _depatrmentService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
