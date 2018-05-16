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
    public class OlympiadTeamController : Controller
    {
        private IService<OlympiadTeamDTO> _olympiadTeamService;
        private IService<TeamDTO> _teamService;
        private IService<OlympiadDTO> _olympiadService;
        private IService<InstructorDTO> _instructorService;

        public OlympiadTeamController(IService<OlympiadTeamDTO> olympiadTeamService, IService<TeamDTO> teamService, IService<OlympiadDTO> olympiadService, IService<InstructorDTO> instructorService)
        {
            _olympiadTeamService = olympiadTeamService;
            _teamService = teamService;
            _olympiadService = olympiadService;
            _instructorService = instructorService;
        }
        //
        // GET: /OlympiadTeam/
        public ActionResult Index()
        {
            IEnumerable<OlympiadTeamDTO> olympiadTeamDtos = _olympiadTeamService.GetItems();
            var olympiadTeams = Mapper.Map<IEnumerable<OlympiadTeamDTO>, List<OlympiadTeamViewModel>>(olympiadTeamDtos);
            return View(olympiadTeams);
        }

        //
        // GET: /OlympiadTeam/Create
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
        // POST: /OlympiadTeam/Create
        [HttpPost]
        public ActionResult Create(OlympiadTeamViewModel olympiadTeam)
        {
            _olympiadTeamService.AddNewItem(new OlympiadTeamDTO()
                {
                    OlympiadTeamID = olympiadTeam.OlympiadTeamID,
                    OlympiadID = olympiadTeam.OlympiadID,
                    TeamID = olympiadTeam.TeamID,
                    InstructorID = olympiadTeam.InstructorID,
                    TeamPlace = olympiadTeam.TeamPlace,
                    Prize = olympiadTeam.Prize
                });
            
            return RedirectToAction("Index");
        }

        //
        // GET: /OlympiadTeam/Edit/5
        public ActionResult Edit(int id)
        {
            OlympiadTeamDTO olympiadTeamDto = _olympiadTeamService.GetItem(id);
            var olympiadTeam = Mapper.Map<OlympiadTeamDTO, OlympiadTeamViewModel>(olympiadTeamDto);
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
            return View(olympiadTeam);
        }

        //
        // POST: /OlympiadTeam/Edit/5
        [HttpPost]
        public ActionResult Edit(OlympiadTeamViewModel olympiadTeam)
        {
            _olympiadTeamService.UpdateItem(new OlympiadTeamDTO()
            {
                OlympiadTeamID = olympiadTeam.OlympiadTeamID,
                OlympiadID = olympiadTeam.OlympiadID,
                TeamID = olympiadTeam.TeamID,
                InstructorID = olympiadTeam.InstructorID,
                TeamPlace = olympiadTeam.TeamPlace,
                Prize = olympiadTeam.Prize
            });
            return RedirectToAction("Index");
        }

        //
        // GET: /OlympiadTeam/Delete/5
        public ActionResult Delete(int? id)
        {
            OlympiadTeamDTO olympiadTeamDto = _olympiadTeamService.GetItem(id);
            var olympiadTeam = Mapper.Map<OlympiadTeamDTO, OlympiadTeamViewModel>(olympiadTeamDto);
            return View(olympiadTeam);
        }

        //
        // POST: /OlympiadTeam/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _olympiadTeamService.DeleteItem(id);
            return RedirectToAction("Index");
        }
	}
}