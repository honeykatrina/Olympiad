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

        //
        // GET: /Olympiad/Create
        public ActionResult Create()
        {
            var allUniversities = _universityService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var univ in allUniversities)
            {
                items.Add(new SelectListItem()
                {
                    Text = univ.UniversityName,
                    Value = univ.UniversityID.ToString()
                });
            }
            ViewBag.Universities = items;
            return View();
        }

        //
        // POST: /Olympiad/Create
        [HttpPost]
        public ActionResult Create(OlympiadViewModel olympiad)
        {
            _olympiadService.AddNewItem(new OlympiadDTO()
            {
                OlympiadID = olympiad.OlympiadID,
                OlympiadName = olympiad.OlympiadName,
                OlympiadLevel = olympiad.OlympiadLevel,
                OlympiadStartDate = olympiad.OlympiadStartDate,
                OlympiadEndDate = olympiad.OlympiadEndDate,
                OlympiadDirection = olympiad.OlympiadDirection,
                OlympiadType = olympiad.OlympiadType,
                UniversityID = olympiad.UniversityID
            });

            return RedirectToAction("Index");
        }

        //
        // GET: /Olympiad/Edit/5
        public ActionResult Edit(int id)
        {
            OlympiadDTO olympiadDto = _olympiadService.GetItem(id);
            var allUniversities = _universityService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var univ in allUniversities)
            {
                items.Add(new SelectListItem()
                {
                    Text = univ.UniversityName,
                    Value = univ.UniversityID.ToString()
                });
            }
            ViewBag.Universities = items;
            
            var olympiad = Mapper.Map<OlympiadDTO, OlympiadViewModel>(olympiadDto);
            return View(olympiad);
        }

        //
        // POST: /Olympiad/Edit/5
        [HttpPost]
        public ActionResult Edit(OlympiadViewModel olympiad)
        {
            _olympiadService.UpdateItem(new OlympiadDTO()
            {
                OlympiadID = olympiad.OlympiadID,
                OlympiadName = olympiad.OlympiadName,
                OlympiadLevel = olympiad.OlympiadLevel,
                OlympiadStartDate = olympiad.OlympiadStartDate,
                OlympiadEndDate = olympiad.OlympiadEndDate,
                OlympiadDirection = olympiad.OlympiadDirection,
                OlympiadType = olympiad.OlympiadType,
                UniversityID = olympiad.UniversityID
            });
            return RedirectToAction("Index");
        }

        //
        // GET: /Olympiad/Delete/5
        public ActionResult Delete(int? id)
        {
            OlympiadDTO olympiadDto = _olympiadService.GetItem(id);
            var universityForName = _universityService.GetItem(olympiadDto.UniversityID);
            ViewBag.University = universityForName.UniversityName;
            var olympiad = Mapper.Map<OlympiadDTO, OlympiadViewModel>(olympiadDto);
            return View(olympiad);
        }

        //
        // POST: /Olympiad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            _olympiadService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
