using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HIT339_Assignment_1.Data;
using HIT339_Assignment_1.Models;

namespace HIT339_Assignment_1.Controllers
{
    public class LessonsController : Controller
    {
        private readonly HIT339_Assignment_1Context _context;

        public LessonsController(HIT339_Assignment_1Context context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(int ? id)
        {
            if (id == null)
            {
                var hIT339_Assignment_1Context = _context.Lesson
                    .Include(l => l.Instructor)
                    .Include(l => l.Instrument)
                    .Include(l => l.Student);
                return View(await hIT339_Assignment_1Context.ToListAsync());
            }
            else
            {
                var hIT339_Assignment_1Context = _context.Lesson
                    .Where(l => l.StudentID == id);
                return View(await hIT339_Assignment_1Context.ToListAsync());
            }
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Instructor)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "Id", "Reference");
            ViewData["InstrumentID"] = new SelectList(_context.Instrument, "id", "InstrumentName");
            ViewData["StudentID"] = new SelectList(_context.Student, "Id", "Reference");
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(SemesterType)));
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["LessonDuration"] = new SelectList(Enum.GetValues(typeof(LessonDurationType)));
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentID,InstructorID,InstrumentID,Semester,Term,LessonDate,LessonDuration,Paid")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "Id", "Id", lesson.InstructorID);
            ViewData["InstrumentID"] = new SelectList(_context.Instrument, "id", "id", lesson.InstrumentID);
            ViewData["StudentID"] = new SelectList(_context.Student, "Id", "Id", lesson.StudentID);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "Id", "IFullName", lesson.InstructorID);
            ViewData["InstrumentID"] = new SelectList(_context.Instrument, "id", "InstrumentName", lesson.InstrumentID);
            ViewData["StudentID"] = new SelectList(_context.Student, "Id", "SFullName", lesson.StudentID);
            ViewData["Term"] = new SelectList(Enum.GetValues(typeof(TermType)));
            ViewData["Semester"] = new SelectList(Enum.GetValues(typeof(SemesterType)));
            ViewData["LessonDuration"] = new SelectList(Enum.GetValues(typeof(LessonDurationType)));
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentID,InstructorID,InstrumentID,Semester,Term,LessonDate,LessonDuration,Paid")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
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
            ViewData["InstructorID"] = new SelectList(_context.Instructor, "Id", "Id", lesson.InstructorID);
            ViewData["InstrumentID"] = new SelectList(_context.Instrument, "id", "id", lesson.InstrumentID);
            ViewData["StudentID"] = new SelectList(_context.Student, "Id", "Id", lesson.StudentID);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Instructor)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Id == id);
        }
    }
}
