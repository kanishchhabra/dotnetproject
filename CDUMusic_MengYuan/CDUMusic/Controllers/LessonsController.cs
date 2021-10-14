using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CDUMusic.Data;
using CDUMusic.Models;

namespace CDUMusic.Controllers
{
    public class LessonsController : Controller
    {
        private readonly CDUMusicContext _context;

        public LessonsController(CDUMusicContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var cDUMusicContext = _context.Lesson.Include(l => l.Duration).Include(l => l.Instrument).Include(l => l.Tutor);
            return View(await cDUMusicContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["DurationId"] = new SelectList(_context.Duration, "DurationId", "DurationId");
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "InstrumentId", "InstrumentName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "FirstName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,LessonName,TutorId,InstrumentId,LessonYear,LessonTerm,LessonDate,LessonTime,DurationId")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationId"] = new SelectList(_context.Duration, "DurationId", "DurationId", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "FirstName", lesson.TutorId);
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
            ViewData["DurationId"] = new SelectList(_context.Duration, "DurationId", "DurationId", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "FirstName", lesson.TutorId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,LessonName,TutorId,InstrumentId,LessonYear,LessonTerm,LessonDate,LessonTime,DurationId")] Lesson lesson)
        {
            if (id != lesson.LessonId)
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
                    if (!LessonExists(lesson.LessonId))
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
            ViewData["DurationId"] = new SelectList(_context.Duration, "DurationId", "DurationId", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "InstrumentId", "InstrumentName", lesson.InstrumentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "TutorId", "FirstName", lesson.TutorId);
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
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.LessonId == id);
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
            return _context.Lesson.Any(e => e.LessonId == id);
        }
    }
}
