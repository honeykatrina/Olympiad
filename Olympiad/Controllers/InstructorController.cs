using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
    }
}
