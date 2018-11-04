using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class OlympiadController : Controller
    {
        private IService<OlympiadDTO> _olympiadService;
        private IService<UniversityDTO> _universityService;

        public OlympiadController(IService<OlympiadDTO> olympiadService, IService<UniversityDTO> universityService)
        {
            _olympiadService = olympiadService;
            _universityService = universityService;
        }
        //
        // GET: /Olympiad/
        public ActionResult Index()
        {
            IEnumerable<OlympiadDTO> olympiadDtos = _olympiadService.GetItems();
            var olympiads = Mapper.Map<IEnumerable<OlympiadDTO>, List<OlympiadViewModel>>(olympiadDtos);
            return View(olympiads);
        }
    }
}
