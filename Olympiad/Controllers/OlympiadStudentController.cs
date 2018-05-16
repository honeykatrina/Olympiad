using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;

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
            
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        //
        // GET: /OlympiadStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            OlympiadStudentDTO olympiadStudentDto = _olympiadStudentService.GetItem(id);
            var olympiadStudent = Mapper.Map<OlympiadStudentDTO, OlympiadStudentViewModel>(olympiadStudentDto);
            return View(olympiadStudent);
        }

        //
        // POST: /OlympiadStudent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _olympiadStudentService.DeleteItem(id);
            return RedirectToAction("Index");
        }
	}
}