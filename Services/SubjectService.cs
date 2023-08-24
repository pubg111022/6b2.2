using Microsoft.EntityFrameworkCore;
using pdf6b2.Interfaces;
using pdf6b2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf6b2.Services
{
    public class SubjectService : ISubject
    {
        private readonly StudentDbContext _context;

        public SubjectService(StudentDbContext context)
        {
            _context = context;
        }
        public bool DeleteSubject(int id)
        {
            var subject =  _context.Subjects.Find(id);
            if (subject == null)
            {
                return false;
            }

            _context.Subjects.Remove(subject);
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public Subject FindByIdAsync(int id)
        {
            return _context.Subjects.Find(id);
        }

        public List<Subject> GetSubject()
        {
            return _context.Subjects.ToList();
        }

        public bool InsertSubject(Subject s)
        {
            _context.Subjects.Add(s);
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateSubject(Subject s, int id)
        {
            _context.Entry(s).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
                throw;
            }

        }
    }

}
