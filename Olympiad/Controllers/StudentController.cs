using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
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
    }
}
