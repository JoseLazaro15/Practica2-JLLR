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
    public class OfficeAssignmentsController : Controller
    {
        private readonly Practica2BdContext _context;

        public OfficeAssignmentsController(Practica2BdContext context)
        {
            _context = context;
        }

        // GET: OfficeAssignments
        public async Task<IActionResult> Index()
        {
            var practica2BdContext = _context.OfficeAssignments.Include(o => o.Instructor);
            return View(await practica2BdContext.ToListAsync());
        }

        // GET: OfficeAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _context.OfficeAssignments
                .Include(o => o.Instructor)
                .FirstOrDefaultAsync(m => m.OfficeAssignmentID == id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID");
            return View();
        }

        // POST: OfficeAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficeAssignmentID,InstructorID,Location")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(officeAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfficeAssignmentID,InstructorID,Location")] OfficeAssignment officeAssignment)
        {
            if (id != officeAssignment.OfficeAssignmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeAssignmentExists(officeAssignment.OfficeAssignmentID))
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
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "InstructorID", "InstructorID", officeAssignment.InstructorID);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _context.OfficeAssignments
                .Include(o => o.Instructor)
                .FirstOrDefaultAsync(m => m.OfficeAssignmentID == id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);
            _context.OfficeAssignments.Remove(officeAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeAssignmentExists(int id)
        {
            return _context.OfficeAssignments.Any(e => e.OfficeAssignmentID == id);
        }
    }
}
