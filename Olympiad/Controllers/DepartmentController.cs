using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class DepartmentController : Controller
    {
        private IService<DepartmentDTO> _depatrmentService;

        public DepartmentController(IService<DepartmentDTO> depatrmentService)
        {
            _depatrmentService = depatrmentService;
        }
        //
        // GET: /Department/
        public ActionResult Index()
        {
            IEnumerable<DepartmentDTO> departmentDtos = _depatrmentService.GetItems();
            var departments = Mapper.Map<IEnumerable<DepartmentDTO>, List<DepartmentViewModel>>(departmentDtos);
            return View(departments);
        }
    }
}
