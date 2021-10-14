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
    public class LettersController : Controller
    {
        private readonly StudentsContext _context;

        public LettersController(StudentsContext context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            var studentsContext = _context.Letter.Include(l => l.Lesson);
            return View(await studentsContext.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.LetterId == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letters/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = new SelectList(_context.Lesson, "LessonId", "LessonId");
            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LetterId,LessonId,Bank,ReferenceNo,Comment,SigEmail,AccName,BSB,AccNo")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = new SelectList(_context.Lesson, "LessonId", "LessonId", letter.LessonId);
            return View(letter);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = new SelectList(_context.Lesson, "LessonId", "LessonId", letter.LessonId);
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LetterId,LessonId,Bank,ReferenceNo,Comment,SigEmail,AccName,BSB,AccNo")] Letter letter)
        {
            if (id != letter.LetterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterExists(letter.LetterId))
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
            ViewData["LessonId"] = new SelectList(_context.Lesson, "LessonId", "LessonId", letter.LessonId);
            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.LetterId == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letter = await _context.Letter.FindAsync(id);
            _context.Letter.Remove(letter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
            return _context.Letter.Any(e => e.LetterId == id);
        }


        // GET: Lessons/Letter/5
        public async Task<IActionResult> Letter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Letter
                .Include(l => l.Lesson)
                .FirstOrDefaultAsync(m => m.LetterId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }
    }
}
