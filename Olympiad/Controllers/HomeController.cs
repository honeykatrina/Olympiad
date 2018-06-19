using LogicLayer.Interfaces;
using System.Web.Mvc;

namespace Olympiad.Controllers
{
    public class HomeController : Controller
    {
        private IReportService _reportService;

        public HomeController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ReportFirst()
        {
            return File(_reportService.ReportFirst(), "application/octet-stream", "Участие в олимпиадах по программированию.docx");
        }


        public ActionResult ReportSecond()
        {
            return File(_reportService.ReportSecond(), "application/octet-stream", "Участие в олимпиадах по программированию.docx");
        }
        
    }
}