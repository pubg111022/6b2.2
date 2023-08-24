using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdf6b2.Interfaces;
using pdf6b2.Models;

namespace pdf6b2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly ISubject _subject;

        public SubjectsController(ISubject subject)
        {
            _subject = subject;
        }

        // GET: api/Subjects
        [HttpGet]
        public IEnumerable<Subject> GetSubjects()
        {
            return _subject.GetSubject().ToList();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public Subject GetSubject([FromRoute] int id)
        {
           
            return _subject.FindByIdAsync(id);
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject([FromRoute] int id, [FromBody] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.Id)
            {
                return BadRequest();
            }

            if (_subject.UpdateSubject(subject, id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }


        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<IActionResult> PostSubject([FromBody] Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_subject.InsertSubject(subject))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_subject.DeleteSubject(id))
            {
                return Ok(_subject.FindByIdAsync(id));
            }
            else
            {
                return Ok("Fail");
            }

        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}