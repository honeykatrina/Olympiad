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

        // GET: University/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        [HttpPost]
        public ActionResult Create(UniversityViewModel university)
        {
            //try
            //{
            _universityService.AddNewItem(new UniversityDTO()
            {
               UniversityID= university.UniversityID,
                UniversityName = university.City,
                City = university.City,
                Country = university.Country,
            });

            return RedirectToAction("Index");
            //}
            // catch
            //{
            //  return View();
            // }
        }

        // GET: University/Edit/5
        public ActionResult Edit(int id)
        {
            UniversityDTO universityDto = _universityService.GetItem(id);

            var university = Mapper.Map<UniversityDTO, UniversityViewModel>(universityDto);
            return View(university);
        }

        // POST: University/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UniversityDTO university)
        {
            //try
            //{
            _universityService.UpdateItem(university);
            return RedirectToAction("Index");

            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: University/Delete/5
        public ActionResult Delete(int? id)
        {
            UniversityDTO universityDto = _universityService.GetItem(id);
            var university = Mapper.Map<UniversityDTO, UniversityViewModel>(universityDto);
            return View(university);
        }

        // POST: University/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            _universityService.DeleteItem(id);
            return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}