﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Areas.Admin.Models;

namespace Olympiad.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class StudentTeamController : Controller
    {
        private IService<StudentTeamDTO> _studentTeamService;
        private IService<TeamDTO> _teamService;
        private IService<StudentDTO> _studentService;

        public StudentTeamController(IService<StudentTeamDTO> studentTeamService, IService<TeamDTO> teamService, IService<StudentDTO> studService)
        {
            _studentTeamService = studentTeamService;
            _teamService = teamService;
            _studentService = studService;
        }
        //
        // GET: /StudentTeam/
        public ActionResult Index()
        {
            IEnumerable<StudentTeamDTO> studentTeamDtos = _studentTeamService.GetItems();
            var studentTeams = Mapper.Map<IEnumerable<StudentTeamDTO>, List<StudentTeamViewModel>>(studentTeamDtos);
            return View(studentTeams);
        }

        //
        // GET: /StudentTeam/Create
        public ActionResult Create()
        {
            var allTeams = _teamService.GetItems();
            var itemsTeams = new List<SelectListItem>();

            foreach (var st in allTeams)
            {
                itemsTeams.Add(new SelectListItem()
                {
                    Text = st.TeamName,
                    Value = st.TeamID.ToString()
                });
            }
            ViewBag.Teams = itemsTeams;

            var allStudents = _studentService.GetItems();
            var itemsStudents = new List<SelectListItem>();
            foreach (var st in allStudents)
            {
                itemsStudents.Add(new SelectListItem()
                {
                    Text = st.StudentSurname + " " + st.StudentName,
                    Value = st.StudentID.ToString()
                });
            }
           ViewBag.Students = itemsStudents;
            return View();
        }

        public ActionResult GetStudents(int id)
        {
            var allStudents = _studentService.GetItems();
            List<StudentTeamDTO> studentTeamDtos = _studentTeamService.GetItems().ToList();
            var studentsOfTeam = new List<StudentDTO>();
            foreach (var st in studentTeamDtos)
           {
                if (st.Team.TeamID == id)
                {
                    studentsOfTeam.Add(st.Student);
                }
           }           

            var itemsStudents = new List<SelectListItem>();
            foreach (var st in allStudents)
            {
                if ((studentsOfTeam.Find(x=>x.StudentID==st.StudentID)==null))
                {
                    itemsStudents.Add(new SelectListItem()
                    {
                        Text = st.StudentSurname+" " + st.StudentName,
                        Value = st.StudentID.ToString()
                   });
               }
            }
            ViewBag.Students = itemsStudents;
            return PartialView();
        }

        //
        // POST: /StudentTeam/Create
        [HttpPost]
        public ActionResult Create(StudentTeamViewModel studentTeam)
        {
            _studentTeamService.AddNewItem(new StudentTeamDTO()
                {
                    StudentTeamID = studentTeam.StudentTeamID,
                    StudentID = studentTeam.StudentID,
                    TeamID = studentTeam.TeamID
                });
            
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //
        // GET: /StudentTeam/Edit/5
        public ActionResult Edit(int id)
        {
            StudentTeamDTO studentTeamDto = _studentTeamService.GetItem(id);
            var studentTeam = Mapper.Map<StudentTeamDTO, StudentTeamViewModel>(studentTeamDto);
            var allStudents = _studentService.GetItems();
            var itemsStudents = new List<SelectListItem>();

            foreach (var st in allStudents)
            {
                itemsStudents.Add(new SelectListItem()
                {
                    Text = st.StudentName,
                    Value = st.StudentID.ToString()
                });
            }
            ViewBag.Students = itemsStudents;

            var allTeams = _teamService.GetItems();
            var itemsTeams = new List<SelectListItem>();

            foreach (var st in allTeams)
            {
                itemsTeams.Add(new SelectListItem()
                {
                    Text = st.TeamName,
                    Value = st.TeamID.ToString()
                });
            }
            ViewBag.Teams = itemsTeams;
            return View(studentTeam);
        }

        //
        // POST: /StudentTeam/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentTeamViewModel studentTeam)
        {
            _studentTeamService.UpdateItem(new StudentTeamDTO()
            {
                StudentTeamID = studentTeam.StudentTeamID,
                 StudentID = studentTeam.StudentID,
                 TeamID = studentTeam.TeamID
            });
            return RedirectToAction("Index", new { area = "Admin" });
        }

        //
        // GET: /StudentTeam/Delete/5
        public ActionResult Delete(int? id)
        {
            StudentTeamDTO studentTeamDto = _studentTeamService.GetItem(id);
            var studentDto = _studentService.GetItem(studentTeamDto.StudentID);
            ViewBag.Student = studentDto.StudentSurname + " " + studentDto.StudentName + " " + studentDto.StudentPatronymic;
            var teamDto = _teamService.GetItem(studentTeamDto.TeamID);
            ViewBag.Team = teamDto.TeamName;
            var studentTeam = Mapper.Map<StudentTeamDTO, StudentTeamViewModel>(studentTeamDto);
            return View(studentTeam);
        }

        //
        // POST: /StudentTeam/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _studentTeamService.DeleteItem(id);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
