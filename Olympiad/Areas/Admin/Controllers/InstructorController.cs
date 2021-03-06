﻿using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
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
                InstructorName = instructor.InstructorName,
                InstructorSurname = instructor.InstructorSurname,
                InstructorPatronymic = instructor.InstructorPatronymic,
                InstructorTitle = instructor.InstructorTitle,
                InstructorDegree = instructor.InstructorDegree,
                InstructorPosition = instructor.InstructorPosition,
                DepartmentId = instructor.DepartmentId
            });

            return RedirectToAction("Index", new { area = "Admin" });
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
                InstructorName = instructor.InstructorName,
                InstructorSurname = instructor.InstructorSurname,
                InstructorPatronymic = instructor.InstructorPatronymic,
                InstructorTitle = instructor.InstructorTitle,
                InstructorDegree = instructor.InstructorDegree,
                InstructorPosition =instructor.InstructorPosition,
                DepartmentId =instructor.DepartmentId
    });
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //
        // GET: /Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            InstructorDTO instructorDto = _instructorService.GetItem(id);
            var departmentDto = _depatrmentService.GetItem(instructorDto.DepartmentId);
            ViewBag.Departments = departmentDto.DepartmentName;
           
            var instructor = Mapper.Map<InstructorDTO, InstructorViewModel>(instructorDto);
            return View(instructor);
        }

        //
        // POST: /Instructor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _instructorService.DeleteItem(id);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
