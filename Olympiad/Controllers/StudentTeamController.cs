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
        // GET: /Team/
        public ActionResult Index()
        {
            IEnumerable<StudentTeamDTO> studentTeamDtos = _studentTeamService.GetItems();
            var studentTeams = Mapper.Map<IEnumerable<StudentTeamDTO>, List<StudentTeamViewModel>>(studentTeamDtos);
            return View(studentTeams);
        }

        //
        // GET: /Team/Create
        public ActionResult Create()
        {
            var allStudents = _studentService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var st in allStudents)
            {
                items.Add(new SelectListItem()
                {
                    Text = st.StudentName,
                    Value = st.StudentID.ToString()
                });
            }
            ViewBag.Students = items;
            return View();
        }

        //
        // POST: /Team/Create
        [HttpPost]
        public ActionResult Create(StudentTeamViewModel studentTeam)
        {
            //if(_studentTeamService.GetItem(studentTeam.StudentTeamID).TeamID != studentTeam.TeamID &&
            //    _studentTeamService.GetItem(studentTeam.StudentTeamID).StudentID != studentTeam.StudentID)
            //{
                _teamService.AddNewItem(new TeamDTO()
                {
                    TeamID = studentTeam.Team.TeamID,
                    TeamName = studentTeam.Team.TeamName
                });
                _studentTeamService.AddNewItem(new StudentTeamDTO()
                {
                    StudentTeamID = studentTeam.StudentTeamID,
                    StudentID = studentTeam.Student.StudentID,
                    TeamID = studentTeam.Team.TeamID
                });
            //}
            
            return RedirectToAction("Index");
        }

        //
        // GET: /Team/Edit/5
        public ActionResult Edit(int id)
        {
            //TeamDTO teamDto = _teamService.GetItem(id);
            //var team = Mapper.Map<TeamDTO, TeamViewModel>(teamDto);
            //return View(team);
            return View();
        }

        //
        // POST: /Team/Edit/5
        [HttpPost]
        public ActionResult Edit(TeamViewModel team)
        {
            //_teamService.UpdateItem(new TeamDTO()
            //{
            //    TeamID = team.TeamID,
            //    TeamName = team.TeamName
            //});
            return RedirectToAction("Index");
        }

        //
        // GET: /Team/Delete/5
        public ActionResult Delete(int? id)
        {
            //TeamDTO teamDto = _teamService.GetItem(id);
            //var team = Mapper.Map<TeamDTO, TeamViewModel>(teamDto);
            //return View(team);
            return View();
        }

        //
        // POST: /Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _studentTeamService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
