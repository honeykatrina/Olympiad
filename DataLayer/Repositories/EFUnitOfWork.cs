using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private OlympiadContext _context;
        private DepartmentRepository _departmentRepository;
        private InstructorRepository _instructorRepository;
        private OlympiadRepository _olympiadRepository;
        private StudentRepository _studentRepository;
        private TeamRepository _teamRepository;
        private UniversityRepository _universityRepository;

        public EFUnitOfWork(string connectionString)
        {
            _context = new OlympiadContext(connectionString);
        }
        public IRepository<Department> Department
        {
            get
            {
                if (_departmentRepository == null)
                    _departmentRepository = new DepartmentRepository(_context);
                return _departmentRepository;
            } 
        }

        public IRepository<Instructor> Instructor
        {
            get
            {
                if (_instructorRepository == null)
                    _instructorRepository = new InstructorRepository(_context);
                return _instructorRepository;
            } 
        }

        public IRepository<Olympiad> Olympiad
        {
            get
            {
                if (_olympiadRepository == null)
                    _olympiadRepository = new OlympiadRepository(_context);
                return _olympiadRepository;
            } 
        }

        public IRepository<Student> Student
        {
            get
            {
                if (_studentRepository == null)
                    _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            } 
        }

        public IRepository<Team> Team
        {
            get
            {
                if (_teamRepository == null)
                    _teamRepository = new TeamRepository(_context);
                return _teamRepository;
            } 
        }

        public IRepository<University> University
        {
            get
            {
                if (_universityRepository == null)
                    _universityRepository = new UniversityRepository(_context);
                return _universityRepository;
            } 
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}