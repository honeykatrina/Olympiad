﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DataLayer.Models;

namespace DataLayer.Context
{
    public class ContextInitializer: DropCreateDatabaseAlways<OlympiadContext>
    {
        protected override void Seed(OlympiadContext context)
        {
            var students = new List<Student>
            {
            new Student{StudentName="Carson", StudentSurname ="Alexander", StudentID = 1, StudentPatronymic="fgfgfg", Course = 2, Group="212", Specialty = "bgg", DepartmentId = 1},
            new Student{StudentName="Meredith",StudentSurname="Alonso", StudentID = 2, StudentPatronymic="fgfgfg", Course = 1, Group="212", Specialty = "bgg", DepartmentId = 2},
            new Student{StudentName="Arturo",StudentSurname="Anand", StudentID = 3, StudentPatronymic="fgfgfg", Course = 3, Group="212", Specialty = "bgg", DepartmentId = 1},
            new Student{StudentName="Gytis",StudentSurname="Barzdukas", StudentID = 4, StudentPatronymic="fgfgfg", Course = 4, Group="212", Specialty = "bgg", DepartmentId = 2}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var departments = new List<Department>
            {
            new Department{DepartmentID = 1, DepartmentName ="first"},
            new Department{DepartmentID = 2, DepartmentName ="second"}
            };

            departments.ForEach(s => context.Departments.Add(s));
            context.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { InstructorID = 1, InstructorName = "ggss", InstructorSurname="rhbwr",
                    InstructorPatronymic ="grwgw", InstructorTitle = "grgw", InstructorDegree = "rger",
                    InstructorPosition = "gr", DepartmentId = 1},
                new Instructor { InstructorID = 2, InstructorName = "ggrrrrrrrgwrhwss", InstructorSurname="hethaearhbwr",
                    InstructorPatronymic ="ghaerarwgw", InstructorTitle = "grhrgw", InstructorDegree = "rger",
                    InstructorPosition = "gr", DepartmentId = 2}
            };
            instructors.ForEach(s => context.Instructors.Add(s));
            context.SaveChanges();

            var olympiads = new List<Olympiad>
            {
                new Olympiad { OlympiadID = 223, OlympiadName = "ol1", OlympiadLevel = "rgr",
                    OlympiadStartDate = DateTime.Parse("2005-09-01"), OlympiadEndDate = DateTime.Parse("2005-09-01"),
                    OlympiadDirection = "fbdb", OlympiadType = "fvd", UniversityID = 1},
                new Olympiad { OlympiadID = 224, OlympiadName = "ol2", OlympiadLevel = "rgr",
                    OlympiadStartDate = DateTime.Parse("2017-09-01"), OlympiadEndDate = DateTime.Parse("2017-09-01"),
                    OlympiadDirection = "fbdb", OlympiadType = "fvd", UniversityID = 2}
            };
            olympiads.ForEach(s => context.Olympiads.Add(s));
            context.SaveChanges();

            var olympiadstudents = new List<OlympiadStudent>
            {
                new OlympiadStudent { StudentID = 1, InstructorID = 1, OlympiadID = 223, StudentPlace = 2},
                new OlympiadStudent { StudentID = 2, InstructorID = 1, OlympiadID = 223, StudentPlace = 1},
                new OlympiadStudent { StudentID = 3, InstructorID = 2, OlympiadID = 224, StudentPlace = 10}
            };
            olympiadstudents.ForEach(s => context.OlympiadStudents.Add(s));
            context.SaveChanges();

            var olympiadteams = new List<OlympiadTeam>
            {
                new OlympiadTeam { OlympiadID = 223, InstructorID = 1, TeamID = 1, TeamPlace = 3},
                new OlympiadTeam { OlympiadID = 224, InstructorID = 2, TeamID = 2, TeamPlace = 1 }
            };
            olympiadteams.ForEach(s => context.OlympiadTeams.Add(s));
            context.SaveChanges();

            var studentteams = new List<StudentTeam>
            {
                new StudentTeam { TeamID = 1, StudentID = 1},
                new StudentTeam { TeamID = 1, StudentID = 2},
                new StudentTeam { TeamID = 2, StudentID = 3},
                new StudentTeam { TeamID = 2, StudentID = 4}
            };
            studentteams.ForEach(s => context.StudentTeams.Add(s));
            context.SaveChanges();

            var teams = new List<Team>
            {
                new Team { TeamID = 1, TeamName = "team1"},
                new Team { TeamID = 2, TeamName = "team2"}
            };
            teams.ForEach(s => context.Teams.Add(s));
            context.SaveChanges();

            var universities = new List<University>
            {
                new University { UniversityID = 1, City = "fsf", Country = "fs", UniversityName = "fssdv"},
                new University { UniversityID = 2, City = "bsnh", Country = "gsbfs", UniversityName = "sgbs"},
            };
            universities.ForEach(s => context.Universities.Add(s));
            context.SaveChanges();
        }
    }
}