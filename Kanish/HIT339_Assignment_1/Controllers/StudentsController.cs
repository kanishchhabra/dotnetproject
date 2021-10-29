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
    public class StudentsController : Controller
    {
        private readonly HIT339_Assignment_1Context _context;

        public StudentsController(HIT339_Assignment_1Context context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["Gender"] = new SelectList(Enum.GetValues(typeof(GenderType)));
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Age,Gender,ParentGuardianName,PaymentEmailAddress,PaymentPhoneNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                TimeSpan age = DateTime.Now - student.DateOfBirth;
                student.Age = (int)(age.TotalDays / 365);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Gender"] = new SelectList(Enum.GetValues(typeof(GenderType)));
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Age,Gender,ParentGuardianName,PaymentEmailAddress,PaymentPhoneNumber")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    TimeSpan age = DateTime.Now - student.DateOfBirth;
                    student.Age = (int)(age.TotalDays / 365);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        //Controls for letter start here
        public async Task<IActionResult> Letter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var s = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);

            if (s == null)
            {
                return NotFound();
            }
            var lessons = _context.Lesson.Where(l => l.StudentID == s.Id).Where(l => l.Paid == false);
            var sum = (float)0.0;
            List<Lesson> viewLessons = new List<Lesson>();
            foreach (Lesson lesson in lessons)
            {
                viewLessons.Add(lesson);
                sum += (float)lesson.LessonDuration;
            }
            var studentLetter = _context.Letter.Where(letter => letter.Student == s);

            if(studentLetter.FirstOrDefault() == null)
            {
                ViewData["Student"] = s.Id;
                return View("LetterCreate");
            }
            else
            {
                Letter letter = studentLetter.FirstOrDefault();
                //Taking $50 as the per hour charge out rate for the class
                letter.Cost = (sum / 60) * 50;
                letter.StudentDetails = s.ToString();
                await _context.SaveChangesAsync();

                // give to view
                ViewData["lessons"] = viewLessons;
                ViewData["student"] = s;
                return View(letter);
            }
        }

        //Following function creates the letter if t has not been created
        //Student ID is passed as key for this function to make the letter for the selected student.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LetterCreate(int id, [Bind("StudentID,StudentDetails,Payment,Reference,Cost,BankName,AccountName,AccountNumber,BSB,Signature")] Letter letter)
        {
            var s = await _context.Student
                .FirstOrDefaultAsync(m => m.Id == id);
            if (s == null)
            {
                return NotFound();
            }
            var lessons = _context
                .Lesson.Where(l => l.StudentID == s.Id).Where(l => l.Paid == false);
            var sum = (float)0.0;
            foreach (Lesson lesson in lessons)
            {
                sum += (float)lesson.LessonDuration;
            }

            //Taking $50 as the per hour charge out rate for the class
            letter.Cost = (sum / 60) * 50;
            letter.Reference = s.LastName + DateTime.UtcNow.ToString("yyyy") + letter.Id;
            letter.Student = s;
            letter.StudentDetails = s.ToString();

            // save to database
            _context.Add(letter);
            await _context.SaveChangesAsync();
            // give to view
            return RedirectToAction("Letter", new { id = id });
        }
        [HttpPost]
        public JsonResult EmailLetter(int id, string mailBody)
        {
            //Getting the relevant student
            var student = _context.Student.Where(m => m.Id == id).FirstOrDefault();

            //Getting all the lessons of that student
            var letter = _context.Letter.Where(l => l.StudentID == student.Id).FirstOrDefault();

            //Email Code
            try
            {
                string senderEmail = "dotnethit339@gmail.com";
                string senderPassword = "cdu@hit339";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, student.PaymentEmailAddress, "Invoice: " + letter.Reference, mailBody);
                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);

                return Json("Email Sent");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
