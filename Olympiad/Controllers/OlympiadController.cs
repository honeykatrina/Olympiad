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
    public class OlympiadController : Controller
    {
        private IService<OlympiadDTO> _olympiadService;
        private IService<UniversityDTO> _univercityService;

        public OlympiadController(IService<OlympiadDTO> olympiadService, IService<UniversityDTO> univercityService)
        {
            _olympiadService = olympiadService;
            _univercityService = univercityService;
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
            var allUnivercities = _univercityService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var univ in allUnivercities)
            {
                items.Add(new SelectListItem()
                {
                    Text = univ.UniversityName,
                    Value = univ.UniversityID.ToString()
                });
            }
            ViewBag.Univercities = items;
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
                OlympiadName = olympiad.OlympiadName
            });

            return RedirectToAction("Index");
        }

        //
        // GET: /Olympiad/Edit/5
        public ActionResult Edit(int id)
        {
            OlympiadDTO olympiadDto = _olympiadService.GetItem(id);
            var allUnivercities = _univercityService.GetItems();
            var items = new List<SelectListItem>();

            foreach (var univ in allUnivercities)
            {
                items.Add(new SelectListItem()
                {
                    Text = univ.UniversityName,
                    Value = univ.UniversityID.ToString()
                });
            }
            ViewBag.Univercities = items;
            
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
                OlympiadName = olympiad.OlympiadName
            });
            return RedirectToAction("Index");
        }

        //
        // GET: /Olympiad/Delete/5
        public ActionResult Delete(int? id)
        {
            OlympiadDTO olympiadDto = _olympiadService.GetItem(id);
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
