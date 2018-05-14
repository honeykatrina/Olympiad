using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;

namespace Olympiad.Controllers
{
    public class InstructorController : Controller
    {
        private IService<InstructorDTO> _instructorService;
        private IService<DepartmentDTO> _depatrmentService;

        public InstructorController(IService<InstructorDTO> instructorService, IService<DepartmentDTO> depatrmentService)
        {
            _instructorService = instructorService;
            _depatrmentService = depatrmentService;
        }
        //
        // GET: /Instructor/
        public ActionResult Index()
        {
            IEnumerable<InstructorDTO> instructorDtos = _instructorService.GetItems();
            var instructors = Mapper.Map<IEnumerable<InstructorDTO>, List<InstructorViewModel>>(instructorDtos);
            return View(instructors);
        }

        //
        // GET: /Instructor/Create
        public ActionResult Create()
        {
            var allDepartments = _depatrmentService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var dep in allDepartments)
            {
                items.Add(new SelectListItem()
                {
                    Text = dep.DepartmentName,
                    Value = dep.DepartmentID.ToString()
                });
            }
            ViewBag.Departments = items;
            return View();
        }

        //
        // POST: /Instructor/Create
        [HttpPost]
        public ActionResult Create(InstructorViewModel instructor)
        {
            _instructorService.AddNewItem(new InstructorDTO()
            {
                InstructorID = instructor.InstructorID,
                InstructorName = instructor.InstructorName
            });

            return RedirectToAction("Index");
        }

        //
        // GET: /Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            InstructorDTO instructorDto = _instructorService.GetItem(id);
            var allDepartments = _depatrmentService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var dep in allDepartments)
            {
                items.Add(new SelectListItem()
                {
                    Text = dep.DepartmentName,
                    Value = dep.DepartmentID.ToString()
                });
            }
            ViewBag.Departments = items;
            
            var instructor = Mapper.Map<InstructorDTO, InstructorViewModel>(instructorDto);
            return View(instructor);
        }

        //
        // POST: /Instructor/Edit/5
        [HttpPost]
        public ActionResult Edit(InstructorViewModel instructor)
        {
            _instructorService.UpdateItem(new InstructorDTO()
            {
                InstructorID = instructor.InstructorID,
                InstructorName = instructor.InstructorName
            });
            return RedirectToAction("Index");
        }

        //
        // GET: /Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            InstructorDTO instructorDto = _instructorService.GetItem(id);
            var instructor = Mapper.Map<InstructorDTO, InstructorViewModel>(instructorDto);
            return View(instructor);
        }

        //
        // POST: /Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _instructorService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
