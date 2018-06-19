using LogicLayer.Interfaces;
using LogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using Xceed.Words.NET;

namespace LogicLayer.Services
{
    public class ReportService:IReportService
    {
        private IService<OlympiadDTO> _olympiadService;
        private IService<OlympiadStudentDTO> _olympiadStudentService;
        private IService<OlympiadTeamDTO> _olympiadTeamService;
        private IService<StudentTeamDTO> _studentTeamService;
        private IService<InstructorDTO> _instructorService;
        public ReportService(IService<OlympiadDTO> olympiadService, IService<OlympiadStudentDTO> olympiadStudentService, IService<OlympiadTeamDTO> olympiadTeamService, IService<StudentTeamDTO> studentTeamService, IService<InstructorDTO> instructorService)
        {
            _olympiadService = olympiadService;
            _olympiadStudentService = olympiadStudentService;
            _olympiadTeamService = olympiadTeamService;
            _studentTeamService = studentTeamService;
            _instructorService = instructorService;
        }
        public string GetNumberOfParticipants(int id)
        {
            List<OlympiadStudentDTO> studentsParticipants = _olympiadStudentService.GetItems().Where(x => x.OlympiadID == id).ToList();
            List<OlympiadTeamDTO> teamsParticipants = _olympiadTeamService.GetItems().Where(x => x.OlympiadID == id).ToList();
            string teams = "";
            int sumOfTeamPlayers = 0;
            if (teamsParticipants.Count > 0)
            {
                switch (teamsParticipants.Count)
                {
                    case 1:
                        teams = " команда";
                        break;
                    case 2:
                    case 3:
                    case 4:
                        teams = " команди";
                        break;
                    default:
                        teams = " команд";
                        break;
                }
                teams = "(" + teamsParticipants.Count.ToString() + teams + ")";
                foreach (var team in teamsParticipants)
                {
                    sumOfTeamPlayers += _studentTeamService.GetItems().Where(x => x.TeamID == team.TeamID).Count();
                }
            }
            int sumTotalOfParticipants = studentsParticipants.Count + sumOfTeamPlayers;
            string students = "";
            switch (sumTotalOfParticipants)
            {
                case 1:
                    students = " студент";
                    break;
                case 2:
                case 3:
                case 4:
                    students = " студенти";
                    break;
                default:
                    students = " студентів";
                    break;
            }
            string NumberOfParticipants = sumTotalOfParticipants.ToString() + students + " " + teams;
            return NumberOfParticipants;
        }

        public string GetInstructor(int id)
        {
            List<int> instructorStudentIds = _olympiadStudentService.GetItems().Where(x => x.OlympiadID == id).GroupBy(x => x.InstructorID).Select(g => g.First()).Select(x => x.InstructorID).ToList();
            List<int> insructorTeamIds = _olympiadTeamService.GetItems().Where(x => x.OlympiadID == id).GroupBy(x => x.InstructorID).Select(g => g.First()).Select(x => x.InstructorID).ToList();
            string instructors = "";


            foreach (var item in instructorStudentIds)
            {
                var instructor = _instructorService.GetItem(item);
                instructors += instructor.InstructorSurname + " " + instructor.InstructorName + " " + instructor.InstructorPatronymic + ", ";

            }

            foreach (var item in insructorTeamIds)
            {
                if (!instructorStudentIds.Contains(item))
                {
                    var instructor = _instructorService.GetItem(item);
                    instructors += instructor.InstructorSurname + " " + instructor.InstructorName + " " + instructor.InstructorPatronymic + ", ";
                }

            }
            instructors = instructors.Substring(0, instructors.Length - 2);
            return instructors;
        }

        public string GetResults(int id)
        {
            string results = "";
            return results;
        }

        public string GetWinners(int id)
        {
            string winners = " ";
            return winners;
        }

        public string GetDate(DateTime d1, DateTime d2)
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture("ua-UA");
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            string rightFormat = "";
            dtfi.AbbreviatedMonthNames = new string[] { "січня", "лютого", "березня",
                                                  "квітня", "травня", "червня",
                                                  "липня", "серпня", "вересня",
                                                  "жовтня", "листопада", "грудня", "" };
            dtfi.AbbreviatedMonthGenitiveNames = dtfi.AbbreviatedMonthNames;
            if (d1 == d2)
                rightFormat = d1.ToString("d MMM yyyy", dtfi) + " року";

            else
                rightFormat = d1.ToString("d MMM yyyy", dtfi) + " року - " + d2.ToString("d MM yyyy", dtfi) + " року";
            return rightFormat;
        }


        public byte[] ReportFirst()
        {
            return null;
        }


        public byte[] ReportSecond()
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
            par.Append("Результати").FontSize(14).Color(Color.Black).Bold().Font("Times New Roman").SpacingAfter(10d).Alignment = Alignment.center;
            
            List<OlympiadDTO> olymps = _olympiadService.GetItems().ToList();

            foreach (var ol in olymps)
            {
                var r = t.InsertRow();
                r.Cells[0].Paragraphs[0].Append(ol.OlympiadName);
                r.Cells[1].Paragraphs[0].Append(ol.OlympiadLevel + ", " + ol.University.City + ", " + ol.University.UniversityName + ", " + GetDate(ol.OlympiadStartDate, ol.OlympiadEndDate));
                r.Cells[2].Paragraphs[0].Append(GetNumberOfParticipants(ol.OlympiadID));
                r.Cells[3].Paragraphs[0].Append(GetInstructor(ol.OlympiadID));
                r.Cells[4].Paragraphs[0].Append(GetResults(ol.OlympiadID));
                
            }
            // Create a large blue border.
            Border b = new Border(BorderStyle.Tcbs_single, BorderSize.two, 0, Color.Black);

            // Set the tables Top, Bottom, Left and Right Borders to b.
            t.SetBorder(TableBorderType.Top, b);
            t.SetBorder(TableBorderType.Bottom, b);
            t.SetBorder(TableBorderType.Left, b);
            t.SetBorder(TableBorderType.Right, b);
            t.SetBorder(TableBorderType.InsideH, b);
            t.SetBorder(TableBorderType.InsideV, b);

            par.InsertTableAfterSelf(t);
            doc.Save();
            return stream.ToArray();
        }
    }
}