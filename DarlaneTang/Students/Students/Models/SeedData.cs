using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Students.Data;
using System;
using System.Linq;

namespace Students.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StudentsContext>>()))
            {
                // Look for any Students
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }

                context.Student.AddRange(

                    new Student
                    {
                        Fname = "Darlane",
                        Lname = "Tang",
                        DOB = DateTime.Parse("2000-2-12"),
                        StudentGender = Gender.Female,
                        PGname = "Mary",
                        Email = "darlanetang@gmail.com",
                        ContactNo = 0412357823
                    },

                    new Student
                    {
                        Fname = "Cameron",
                        Lname = "Hope",
                        DOB = DateTime.Parse("1998-6-14"),
                        StudentGender = Gender.Other,
                        PGname = "Dillion",
                        Email = "cameronhope@gmail.com",
                        ContactNo = 0449744955
                    },
                    new Student
                    {
                        Fname = "Bob",
                        Lname = "Builder",
                        DOB = DateTime.Parse("2006-4-18"),
                        StudentGender = Gender.Male,
                        PGname = "Sally",
                        Email = "Thisislegitemail@gmail.com",
                        ContactNo = 044242573
                    }

                );
                //FOR INSTRUMENTS
                if (context.Instrument.Any())
                {
                    return;   // DB has been seeded
                }
                context.Instrument.AddRange(
                    new Instrument
                    {
                        InstrumentType = "Violin"
                    },
                    new Instrument
                    {
                        InstrumentType = "Piano"
                    },
                    new Instrument
                    {
                        InstrumentType = "Guitar"
                    },
                    new Instrument
                    {
                        InstrumentType = "Bass"
                    },
                    new Instrument
                    {
                        InstrumentType = "Cello"
                    },
                    new Instrument
                    {
                        InstrumentType = "Drums"
                    }
                );
                //FOR DURATIONS TIMES
                if (context.Duration.Any())
                {
                    return;   // DB has been seeded
                }
                context.Duration.AddRange(
                    new Duration
                    {
                        DurationTime = 35,
                        Cost = 40
                    },
                    new Duration
                    {
                        DurationTime = 45,
                        Cost = 50
                    },
                    new Duration
                    {
                        DurationTime = 60,
                        Cost = 70
                    }
                );
                //FOR TUTORS
                if (context.Tutor.Any())
                {
                    return;   // DB has been seeded
                }
                context.Tutor.AddRange(
                    new Tutor
                    {
                        TFname = "Steve",
                        TLname = "Bob",
                        TPhone = "1234567894"
                    },
                    new Tutor
                    {
                    TFname = "Rick",
                        TLname = "James",
                        TPhone = "0482615595"
                    },
                    new Tutor
                    {
                        TFname = "Jane",
                        TLname = "Mary",
                        TPhone = "0412652345"
                    }
                );



                context.SaveChanges();
            }
        }
    }
}