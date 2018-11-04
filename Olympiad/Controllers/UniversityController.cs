using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class UniversityController : Controller
    {
        private IService<UniversityDTO> _universityService;

        public UniversityController(IService<UniversityDTO> universityService)
        {
            _universityService = universityService;
        }
        // GET: University
        public ActionResult Index()
        {
            IEnumerable<UniversityDTO> universityDtos = _universityService.GetItems();
            var universities = Mapper.Map<IEnumerable<UniversityDTO>, List<UniversityViewModel>>(universityDtos);
            return View(universities);
        }
    }
}