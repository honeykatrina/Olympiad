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
	}
}