using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Students.Models;



namespace Students.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext (DbContextOptions<StudentsContext> options)
            : base(options)
        {
        }

        public DbSet<Students.Models.Student> Student { get; set; }

        public DbSet<Students.Models.Lesson> Lesson { get; set; }

        public DbSet<Students.Models.Instrument> Instrument { get; set; }

        public DbSet<Students.Models.Tutor> Tutor { get; set; }

        public DbSet<Students.Models.Duration> Duration { get; set; } 

        public DbSet<Students.Models.Letter> Letter { get; set; }


    }
}


