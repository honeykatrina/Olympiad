using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Areas.Admin.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
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

        //
        // GET: /OlympiadStudent/Create
        public ActionResult Create()
        {
            var allOlympiads = _olympiadService.GetItems();
            var itemsOlympiads = new List<SelectListItem>();

            foreach (var st in allOlympiads)
            {
                itemsOlympiads.Add(new SelectListItem()
                {
                    Text = st.OlympiadName,
                    Value = st.OlympiadID.ToString()
                });
            }
            ViewBag.Olympiads = itemsOlympiads;

            var allStudents = _studentService.GetItems();
            var itemsStudents = new List<SelectListItem>();

            foreach (var st in allStudents)
            {
                itemsStudents.Add(new SelectListItem()
                {
                    Text = st.StudentSurname,
                    Value = st.StudentID.ToString()
                });
            }
            ViewBag.Students = itemsStudents;

            var allInstructors = _instructorService.GetItems();
            var itemsInstructors = new List<SelectListItem>();

            foreach (var st in allInstructors)
            {
                itemsInstructors.Add(new SelectListItem()
                {
                    Text = st.InstructorSurname,
                    Value = st.InstructorID.ToString()
                });
            }
            ViewBag.Instructors = itemsInstructors;


            return View();
        }

        //
        // POST: /OlympiadStudent/Create
        [HttpPost]
        public ActionResult Create(OlympiadStudentViewModel olympiadStudent)
        {
            _olympiadStudentService.AddNewItem(new OlympiadStudentDTO()
                {
                    OlympiadStudentID = olympiadStudent.OlympiadStudentID,
                    OlympiadID = olympiadStudent.OlympiadID,
                    StudentID = olympiadStudent.StudentID,
                    InstructorID = olympiadStudent.InstructorID,
                    StudentPlace = olympiadStudent.StudentPlace,
                    Prize = olympiadStudent.Prize
                });
            
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //
        // GET: /OlympiadStudent/Edit/5
        public ActionResult Edit(int id)
        {
            OlympiadStudentDTO olympiadStudentDto = _olympiadStudentService.GetItem(id);
            var olympiadStudent = Mapper.Map<OlympiadStudentDTO, OlympiadStudentViewModel>(olympiadStudentDto);
            var allOlympiads = _olympiadService.GetItems();
            var itemsOlympiads = new List<SelectListItem>();

            foreach (var st in allOlympiads)
            {
                itemsOlympiads.Add(new SelectListItem()
                {
                    Text = st.OlympiadName,
                    Value = st.OlympiadID.ToString()
                });
            }
            ViewBag.Olympiads = itemsOlympiads;

            var allStudents = _studentService.GetItems();
            var itemsStudents = new List<SelectListItem>();

            foreach (var st in allStudents)
            {
                itemsStudents.Add(new SelectListItem()
                {
                    Text = st.StudentSurname,
                    Value = st.StudentID.ToString()
                });
            }
            ViewBag.Students = itemsStudents;

            var allInstructors = _instructorService.GetItems();
            var itemsInstructors = new List<SelectListItem>();

            foreach (var st in allInstructors)
            {
                itemsInstructors.Add(new SelectListItem()
                {
                    Text = st.InstructorSurname,
                    Value = st.InstructorID.ToString()
                });
            }
            ViewBag.Instructors = itemsInstructors;
            return View(olympiadStudent);
        }

        //
        // POST: /OlympiadStudent/Edit/5
        [HttpPost]
        public ActionResult Edit(OlympiadStudentViewModel olympiadStudent)
        {
            _olympiadStudentService.UpdateItem(new OlympiadStudentDTO()
            {
                OlympiadStudentID = olympiadStudent.OlympiadStudentID,
                OlympiadID = olympiadStudent.OlympiadID,
                StudentID = olympiadStudent.StudentID,
                InstructorID = olympiadStudent.InstructorID,
                StudentPlace = olympiadStudent.StudentPlace,
                Prize = olympiadStudent.Prize
            });
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //
        // GET: /OlympiadStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            OlympiadStudentDTO olympiadStudentDto = _olympiadStudentService.GetItem(id);
            var instructorDto = _instructorService.GetItem(olympiadStudentDto.InstructorID);
            ViewBag.ForInstructor = "Преподаватель";
            ViewBag.Instructor = instructorDto.InstructorSurname + " " + instructorDto.InstructorName + " " + instructorDto.InstructorPatronymic;
            var studentDto = _studentService.GetItem(olympiadStudentDto.StudentID);
            ViewBag.Student = studentDto.StudentSurname + " " + studentDto.StudentName + " " + studentDto.StudentPatronymic;
            var olympiadDto = _olympiadService.GetItem(olympiadStudentDto.OlympiadID);
            ViewBag.Olympiad = olympiadDto.OlympiadName;
            var olympiadStudent = Mapper.Map<OlympiadStudentDTO, OlympiadStudentViewModel>(olympiadStudentDto);
            return View(olympiadStudent);
        }

        //
        // POST: /OlympiadStudent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _olympiadStudentService.DeleteItem(id);
            return RedirectToAction("Index", new { area = "Admin" });
        }
	}
}