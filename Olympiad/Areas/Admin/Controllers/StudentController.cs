using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiad.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentController : Controller
    {
        private IService<StudentDTO> _studentService;
        private IService<DepartmentDTO> _depatrmentService;

        public StudentController(IService<StudentDTO> studService, IService<DepartmentDTO> depatrmentService)
        {
            _studentService = studService;
            _depatrmentService = depatrmentService;
        }
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentDTO> studentDtos = _studentService.GetItems();
            var students = Mapper.Map<IEnumerable<StudentDTO>, List<StudentViewModel>>(studentDtos);
            return View(students);
        }

        // GET: Student/Create
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

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            //try
            //{
                _studentService.AddNewItem(new StudentDTO()
                {
                    StudentID = student.StudentID,
                    StudentName = student.StudentName,
                    StudentSurname = student.StudentSurname,
                    StudentPatronymic = student.StudentPatronymic,
                    Course = student.Course,
                    Specialty = student.Specialty,
                    Group = student.Group,
                    DepartmentId = student.DepartmentId
                });

                return RedirectToAction("Index", new { area = "Admin" });
            //}
           // catch
            //{
              //  return View();
           // }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDTO studentDto = _studentService.GetItem(id);
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
            var student = Mapper.Map<StudentDTO, StudentViewModel>(studentDto);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            //try
            //{
            _studentService.UpdateItem(new StudentDTO()
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                StudentSurname = student.StudentSurname,
                StudentPatronymic = student.StudentPatronymic,
                Course = student.Course,
                Specialty = student.Specialty,
                Group = student.Group,
                DepartmentId = student.DepartmentId
            });
            return RedirectToAction("Index", new { area = "Admin" });
            
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
         
            StudentDTO studentDto = _studentService.GetItem(id);
            var departmentDto = _depatrmentService.GetItem(studentDto.DepartmentId);
            ViewBag.Departments = departmentDto.DepartmentName;
            var student = Mapper.Map<StudentDTO, StudentViewModel>(studentDto);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            _studentService.DeleteItem(id);
                return RedirectToAction("Index", new { area = "Admin" });
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
