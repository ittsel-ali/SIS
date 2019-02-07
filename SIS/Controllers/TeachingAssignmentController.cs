using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIS.Models;

namespace SIS.Controllers
{
    public class TeachingAssignmentController : Controller
    {
        private readonly SISContext _context;

        public TeachingAssignmentController(SISContext context)
        {
            _context = context;
        }

        // GET: TeachingAssignment
        public async Task<IActionResult> Index()
        {
            var sISContext = _context.TeachingAssignment.Include(t => t.Course).Include(t => t.Instructor).Include(t => t.Term);
            return View(await sISContext.ToListAsync());
        }

        // GET: TeachingAssignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingAssignment = await _context.TeachingAssignment
                .Include(t => t.Course)
                .Include(t => t.Instructor)
                .Include(t => t.Term)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (teachingAssignment == null)
            {
                return NotFound();
            }

            return View(teachingAssignment);
        }

        // GET: TeachingAssignment/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId");
            ViewData["TermId"] = new SelectList(_context.StudyTerm, "TermId", "TermId");
            return View();
        }

        // POST: TeachingAssignment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,InstructorId,TermId")] TeachingAssignment teachingAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachingAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", teachingAssignment.InstructorId);
            ViewData["TermId"] = new SelectList(_context.StudyTerm, "TermId", "TermId", teachingAssignment.TermId);
            return View(teachingAssignment);
        }

        // GET: TeachingAssignment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingAssignment = await _context.TeachingAssignment.FindAsync(id);
            if (teachingAssignment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", teachingAssignment.InstructorId);
            ViewData["TermId"] = new SelectList(_context.StudyTerm, "TermId", "TermId", teachingAssignment.TermId);
            return View(teachingAssignment);
        }

        // POST: TeachingAssignment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,InstructorId,TermId")] TeachingAssignment teachingAssignment)
        {
            if (id != teachingAssignment.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachingAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachingAssignmentExists(teachingAssignment.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", teachingAssignment.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "InstructorId", teachingAssignment.InstructorId);
            ViewData["TermId"] = new SelectList(_context.StudyTerm, "TermId", "TermId", teachingAssignment.TermId);
            return View(teachingAssignment);
        }

        // GET: TeachingAssignment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachingAssignment = await _context.TeachingAssignment
                .Include(t => t.Course)
                .Include(t => t.Instructor)
                .Include(t => t.Term)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (teachingAssignment == null)
            {
                return NotFound();
            }

            return View(teachingAssignment);
        }

        // POST: TeachingAssignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachingAssignment = await _context.TeachingAssignment.FindAsync(id);
            _context.TeachingAssignment.Remove(teachingAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachingAssignmentExists(int id)
        {
            return _context.TeachingAssignment.Any(e => e.CourseId == id);
        }
    }
}
