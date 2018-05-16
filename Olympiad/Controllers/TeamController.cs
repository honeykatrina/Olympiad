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
    public class TeamController : Controller
    {
        private IService<TeamDTO> _teamService;

        public TeamController(IService<TeamDTO> teamService)
        {
            _teamService = teamService;
        }
        // GET: Team
        public ActionResult Index()
        {
            IEnumerable<TeamDTO> teamDtos = _teamService.GetItems();
            var teams = Mapper.Map<IEnumerable<TeamDTO>, List<TeamViewModel>>(teamDtos);
            return View(teams);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(TeamViewModel team)
        {
            _teamService.AddNewItem(new TeamDTO()
            {
               TeamID= team.TeamID,
                TeamName = team.TeamName
            });

            return RedirectToAction("Index");
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            TeamDTO teamDto = _teamService.GetItem(id);

            var team = Mapper.Map<TeamDTO, TeamViewModel>(teamDto);
            return View(team);
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeamDTO team)
        {
            _teamService.UpdateItem(team);
            return RedirectToAction("Index");
        }

        // GET: Team/Delete/5
        public ActionResult Delete(int? id)
        {
            TeamDTO teamDto = _teamService.GetItem(id);
            var team = Mapper.Map<TeamDTO, TeamViewModel>(teamDto);
            return View(team);
        }

        // POST: Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _teamService.DeleteItem(id);
            return RedirectToAction("Index");
        }
	}
}