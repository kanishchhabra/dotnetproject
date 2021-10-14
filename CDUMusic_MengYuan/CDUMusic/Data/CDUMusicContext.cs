using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CDUMusic.Models;

namespace CDUMusic.Data
{
    public class CDUMusicContext : DbContext
    {
        public CDUMusicContext (DbContextOptions<CDUMusicContext> options)
            : base(options)
        {
        }

        public DbSet<CDUMusic.Models.Student> Student { get; set; }


        public DbSet<CDUMusic.Models.Instrument> Instrument { get; set; }

        public DbSet<CDUMusic.Models.Duration> Duration { get; set; }

        public DbSet<CDUMusic.Models.Tutor> Tutor{ get; set; }

        public DbSet<CDUMusic.Models.Lesson> Lesson { get; set; }

        public DbSet<CDUMusic.Models.LessonList> LessonList { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write data to the table
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Instrument>().ToTable(nameof(Instrument));
            modelBuilder.Entity<Duration>().ToTable(nameof(Duration));
            modelBuilder.Entity<Tutor>().ToTable(nameof(Tutor));
            modelBuilder.Entity<Lesson>().ToTable(nameof(Lesson));
            modelBuilder.Entity<LessonList>().ToTable(nameof(LessonList));

            modelBuilder.Entity<LessonList>()
                .HasKey(ll => new { ll.LessonId, ll.StudentId });
        }



    }
}
