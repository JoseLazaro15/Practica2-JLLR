using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica2_JLLR.Context;
using Practica2_JLLR.Models;

namespace Practica2_JLLR.Controllers
{
    public class CourseAssigmentsController : Controller
    {
        private readonly Practica2BdContext _context;

        public CourseAssigmentsController(Practica2BdContext context)
        {
            _context = context;
        }

        // GET: CourseAssigments
        public async Task<IActionResult> Index()
        {
            var practica2BdContext = _context.CourseAssigments.Include(c => c.Course).Include(c => c.Instructor);
            return View(await practica2BdContext.ToListAsync());
        }

        // GET: CourseAssigments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseAssigmentID == id);
            if (courseAssigment == null)
            {
                return NotFound();
            }

            return View(courseAssigment);
        }

        // GET: CourseAssigments/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID");
            return View();
        }

        // POST: CourseAssigments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseAssigmentID,CourseID,InstructorID")] CourseAssigment courseAssigment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseAssigment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseAssigment.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", courseAssigment.InstructorID);
            return View(courseAssigment);
        }

        // GET: CourseAssigments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments.FindAsync(id);
            if (courseAssigment == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseAssigment.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", courseAssigment.InstructorID);
            return View(courseAssigment);
        }

        // POST: CourseAssigments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseAssigmentID,CourseID,InstructorID")] CourseAssigment courseAssigment)
        {
            if (id != courseAssigment.CourseAssigmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseAssigment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseAssigmentExists(courseAssigment.CourseAssigmentID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", courseAssigment.CourseID);
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", courseAssigment.InstructorID);
            return View(courseAssigment);
        }

        // GET: CourseAssigments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseAssigment = await _context.CourseAssigments
                .Include(c => c.Course)
                .Include(c => c.Instructor)
                .FirstOrDefaultAsync(m => m.CourseAssigmentID == id);
            if (courseAssigment == null)
            {
                return NotFound();
            }

            return View(courseAssigment);
        }

        // POST: CourseAssigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseAssigment = await _context.CourseAssigments.FindAsync(id);
            _context.CourseAssigments.Remove(courseAssigment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseAssigmentExists(int id)
        {
            return _context.CourseAssigments.Any(e => e.CourseAssigmentID == id);
        }
    }
}
