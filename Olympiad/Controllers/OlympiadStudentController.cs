using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class OlympiadStudentController : Controller
    {
        private IService<OlympiadStudentDTO> _olympiadStudentService;
        private IService<StudentDTO> _studentService;
        private IService<OlympiadDTO> _olympiadService;
        private IService<InstructorDTO> _instructorService;

        public OlympiadStudentController(IService<OlympiadStudentDTO> olympiadStudentService, IService<StudentDTO> studentService, IService<OlympiadDTO> olympiadService, IService<InstructorDTO> instructorService)
        {
            _olympiadStudentService = olympiadStudentService;
            _studentService = studentService;
            _olympiadService = olympiadService;
            _instructorService = instructorService;
        }
        //
        // GET: /OlympiadStudent/
        public ActionResult Index()
        {
            IEnumerable<OlympiadStudentDTO> olympiadStudentDtos = _olympiadStudentService.GetItems();
            var olympiadStudents = Mapper.Map<IEnumerable<OlympiadStudentDTO>, List<OlympiadStudentViewModel>>(olympiadStudentDtos);
            return View(olympiadStudents);
        }
	}
}