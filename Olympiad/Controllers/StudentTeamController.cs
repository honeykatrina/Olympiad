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
        // GET: /StudentTeam/
        public ActionResult Index()
        {
            IEnumerable<StudentTeamDTO> studentTeamDtos = _studentTeamService.GetItems();
            var studentTeams = Mapper.Map<IEnumerable<StudentTeamDTO>, List<StudentTeamViewModel>>(studentTeamDtos);
            return View(studentTeams);
        }
    }
}
