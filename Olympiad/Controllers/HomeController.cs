using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using Xceed.Words.NET;
using AutoMapper;
using LogicLayer.Interfaces;
using LogicLayer.Models;
using Olympiad.Models;

namespace Olympiad.Controllers
{
    public class HomeController : Controller
    {
        private IService<OlympiadDTO> _olympiadService;
        private IService<OlympiadStudentDTO> _olympiadStudentService;
        private IService<OlympiadTeamDTO> _olympiadTeamService;

        public HomeController(IService<OlympiadDTO> olympiadService, IService<OlympiadStudentDTO> olympiadStudentService, IService<OlympiadTeamDTO> olympiadTeamService)
        {
            _olympiadService = olympiadService;
            _olympiadStudentService = olympiadStudentService;
            _olympiadTeamService = olympiadTeamService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public string GetDate(DateTime d1, DateTime d2)
        {
            string rightFormat = " ";
            return rightFormat;
        }
        public ActionResult ReportFirst()
        {
            MemoryStream stream = new MemoryStream();
            DocX doc = DocX.Create(stream);

            var t = doc.AddTable(1, 5);
            t.Design = TableDesign.TableNormal;
            t.Alignment = Alignment.center;
            t.Rows[0].Cells[0].Paragraphs[0].Append("Назва олімпіади");
            t.Rows[0].Cells[1].Paragraphs[0].Append("Місце і дата проведення");
            t.Rows[0].Cells[2].Paragraphs[0].Append("Кількість учасників");
            t.Rows[0].Cells[3].Paragraphs[0].Append("П.І.Б.викладача, який підготував студента");
            t.Rows[0].Cells[4].Paragraphs[0].Append("Нагороди");
            
            Paragraph par = doc.InsertParagraph();
            par.Append("Результати").FontSize(14).Color(Color.Black).Bold().Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.center; ;

           

            List<OlympiadDTO> olymps = _olympiadService.GetItems().ToList();
            
            foreach (var ol in olymps)
            {
                var r = t.InsertRow();
                r.Cells[0].Paragraphs[0].Append(ol.OlympiadName);
                r.Cells[1].Paragraphs[0].Append(ol.OlympiadLevel+", "+ol.University.City+", "+ol.University.UniversityName+", ");
                r.Cells[2].Paragraphs[0].Append("Кількість учасників");
                r.Cells[3].Paragraphs[0].Append("П.І.Б.викладача, який підготував студента");
                r.Cells[4].Paragraphs[0].Append("Нагороди");
            }



            par.InsertTableAfterSelf(t);
            doc.Save();

            return File(stream.ToArray(), "application/octet-stream", "Участие в олимпиадах по программированию.docx");
        }
        public ActionResult ReportSecond()
        {
            return View();
        }
    }
}