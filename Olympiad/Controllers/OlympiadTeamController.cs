using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
	}
}