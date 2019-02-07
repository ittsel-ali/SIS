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
    public class StudyTermController : Controller
    {
        private readonly SISContext _context;

        public StudyTermController(SISContext context)
        {
            _context = context;
        }

        // GET: StudyTerm
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudyTerm.ToListAsync());
        }

        // GET: StudyTerm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTerm = await _context.StudyTerm
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (studyTerm == null)
            {
                return NotFound();
            }

            return View(studyTerm);
        }

        // GET: StudyTerm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudyTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TermId,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerm studyTerm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyTerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyTerm);
        }

        // GET: StudyTerm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTerm = await _context.StudyTerm.FindAsync(id);
            if (studyTerm == null)
            {
                return NotFound();
            }
            return View(studyTerm);
        }

        // POST: StudyTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TermId,TermName,TermStartDate,TermEndDate,TermYear,TermSeason")] StudyTerm studyTerm)
        {
            if (id != studyTerm.TermId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyTerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyTermExists(studyTerm.TermId))
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
            return View(studyTerm);
        }

        // GET: StudyTerm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyTerm = await _context.StudyTerm
                .FirstOrDefaultAsync(m => m.TermId == id);
            if (studyTerm == null)
            {
                return NotFound();
            }

            return View(studyTerm);
        }

        // POST: StudyTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyTerm = await _context.StudyTerm.FindAsync(id);
            _context.StudyTerm.Remove(studyTerm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyTermExists(int id)
        {
            return _context.StudyTerm.Any(e => e.TermId == id);
        }
    }
}
