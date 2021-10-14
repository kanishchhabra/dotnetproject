using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Students.Data;
using Students.Models;

namespace Students.Controllers
{
    public class LessonsController : Controller
    {
        private readonly StudentsContext _context;

        public LessonsController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var lesson = from m in _context.Lesson
                  .Include(l => l.Duration)
                 .Include(l => l.Instrument)
                 .Include(l => l.Student)
                .Include(l => l.Tutor)
                             select m;
                var search = lesson.Where(s => s.Student.Fname.Contains(searchString) || s.Student.Lname.Contains(searchString));
                return View(search);
            }
            else
            {
                var studentsContext = _context.Lesson
                 .Include(l => l.Duration)
                 .Include(l => l.Instrument)
                 .Include(l => l.Student)
                .Include(l => l.Tutor);
                return View(await studentsContext.ToListAsync());
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
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
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
            ViewData["DurationId"] = new SelectList(_context.Set<Duration>(), "DurationId", "DurationTime");
            ViewData["InstrumentId"] = new SelectList(_context.Set<Instrument>(), "InstrumentId", "InstrumentType");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FullName");
            ViewData["TutorId"] = new SelectList(_context.Set<Tutor>(), "TutorId", "TFullName");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,StudentId,TutorId,InstrumentId,Term,TimeYear,DurationId,Paid")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationId"] = new SelectList(_context.Set<Duration>(), "DurationId", "DurationId", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<Instrument>(), "InstrumentId", "InstrumentId", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<Tutor>(), "TutorId", "TutorId", lesson.TutorId);
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
            ViewData["DurationId"] = new SelectList(_context.Set<Duration>(), "DurationId", "DurationTime", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<Instrument>(), "InstrumentId", "InstrumentType", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FullName", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<Tutor>(), "TutorId", "TFullName", lesson.TutorId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,StudentId,TutorId,InstrumentId,Term,TimeYear,DurationId,Paid")] Lesson lesson)
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
            ViewData["DurationId"] = new SelectList(_context.Set<Duration>(), "DurationId", "DurationId", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Set<Instrument>(), "InstrumentId", "InstrumentId", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Set<Tutor>(), "TutorId", "TutorId", lesson.TutorId);
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
                .Include(l => l.Student)
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
        //LETTER
        // GET: Lessons/Letter/5
        public async Task<IActionResult> Letter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Student)
                .Include(l => l.Tutor)
                .Include(l => l.Letter)
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/TogglePaid/5
        public async Task<IActionResult> TogglePaid(int? id)
        {
          if (id != null)
          {
                var lesson = _context.Lesson.Find(id);
                lesson.Paid = lesson.Paid ? false:true;
              _context.Update(lesson);
              await _context.SaveChangesAsync();
          }
          return RedirectToAction(nameof(Index));
         }


        // GET: Lessons/Prepare/1
        public async Task<IActionResult> Prepare(int? id)
        { 
            if(id == null)
            {
                return NotFound();  
            }
            var lesson = _context.Lesson.Find(id);
            ViewData["LessonId"] = new SelectList(_context.Lesson, "LessonId", "LessonId", lesson.LessonId);
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Adds New Letter
        public async Task<IActionResult> Prepare([Bind("LetterId,LessonId,Bank,ReferenceNo,Comment,SigEmail,AccName,BSB,AccNo")] Letter letter)
        {
            {
                if (ModelState.IsValid)
                {
                    _context.Add(letter);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
        }


    }
}
