using CDUMusic.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CDUMusic.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CDUMusicContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student
            {
                FirstName="Carson",
                LastName="Alexander",
                DateOfBirth=DateTime.Parse("1995-09-01"),
                ParentName="D.Alexander",
                PaymentEmail="calex@gmail.com",
                PaymentContact="0465986525" 
            },
            new Student
            {
                FirstName="Meredith",
                LastName="Alonso",
                DateOfBirth=DateTime.Parse("1992-09-01"),
                ParentName="L.Alonso",
                PaymentEmail="malonso@gmail.com",
                PaymentContact="0462686765"
            },
            new Student
            {
                FirstName="Arturo",
                LastName="Anand",
                DateOfBirth=DateTime.Parse("1993-09-01"),
                ParentName="P.Anand",
                PaymentEmail="aanand@gmail.com",
                PaymentContact="0477956266"
            },
            new Student
            {
                FirstName="Gytis",
                LastName="Barzdukas",
                DateOfBirth=DateTime.Parse("1992-09-01"),
                ParentName="A.Barzdukas",
                PaymentEmail="gbarzdukas@gmail.com",
                PaymentContact="0499962658"
            },
            new Student
            {
                FirstName="Yan",
                LastName="Li",
                DateOfBirth=DateTime.Parse("1992-09-01"),
                ParentName="Li Fang",
                PaymentEmail="yanli@gmail.com",
                PaymentContact="0415486956"
            },
            new Student
            {
                FirstName="Peggy",
                LastName="Justice",
                DateOfBirth=DateTime.Parse("1991-09-01"),
                ParentName="O.Justice",
                PaymentEmail="pj@gmail.com",
                PaymentContact="0445785465"
            },                                          
            new Student                                 
            {                                           
                FirstName="Laura",                      
                LastName="Norman",                      
                DateOfBirth=DateTime.Parse("1993-09-01"),
                ParentName="D.Norman",
                PaymentEmail="lnorman@gmail.com",
                PaymentContact="0465219996"
            },                                          
            new Student                                 
            {                                           
                FirstName="Nino",                       
                LastName="Olivetto",                    
                DateOfBirth=DateTime.Parse("1995-09-01"),
                ParentName="L.Olivetto",
                PaymentEmail="nolivetto@gmail.com",
                PaymentContact="0445465485"
            }
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

            var tutors = new Tutor[]
            {
                new Tutor
                {
                    FirstName="Mario",
                    LastName="Olive"
                },
                new Tutor
                {
                    FirstName="Hua",
                    LastName="Zhang"
                },
                new Tutor
                {
                    FirstName="Kim",
                    LastName="Bulo"
                },
            };
            foreach (Tutor t in tutors)
            {
                context.Tutor.Add(t);
            }
            context.SaveChanges();

            var durations = new Duration[]
            {
                new Duration
                {
                    Time = 30,
                    Cost = 200
                },
                new Duration
                {
                    Time = 45,
                    Cost = 300
                },
                new Duration
                {
                    Time = 60,
                    Cost = 400
                },
            };
            foreach(Duration d in durations)
            {
                context.Duration.Add(d);
            }
            context.SaveChanges();

            var instruments = new Instrument[]
            {
            new Instrument
            {
                InstrumentName="Cello",
                InsType=InstrumentType.String
            },
            new Instrument
            {
                InstrumentName="Violin",
                InsType=InstrumentType.String
            },
            new Instrument
            {
                InstrumentName="Guitar",
                InsType=InstrumentType.String
            },
            new Instrument
            {
                InstrumentName="Harp",
                InsType=InstrumentType.String
            },
            new Instrument
            {
                InstrumentName="Cornet",
                InsType=InstrumentType.Brass
            },
            new Instrument
            {
                InstrumentName="Flute",
                InsType=InstrumentType.Woodwind
            },
            new Instrument
            {
                InstrumentName="Saxophone",
                InsType=InstrumentType.Woodwind
            },
            new Instrument
            {
                InstrumentName="Piano",
                InsType=InstrumentType.Keyboard
            },
            new Instrument
            {
                InstrumentName="Drums",
                InsType=InstrumentType.Percussion
            },
            new Instrument
            {
                InstrumentName="Trombone",
                InsType=InstrumentType.Brass
            },
            new Instrument
            {
                InstrumentName="Trumpet",
                InsType=InstrumentType.Brass
            },
            };
            foreach (Instrument i in instruments)
            {
                context.Instrument.Add(i);
            }
            context.SaveChanges();

            var lessons = new Lesson[]
            {
            new Lesson
            {
                LessonName="Introduction to Cornet",
                TutorId=tutors.Single(t => t.LastName == "Olive").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Cornet").InstrumentId,
                LessonYear=1,
                LessonTerm=2,
                LessonDate=Days.Monday,
                LessonTime=DateTime.Parse("6 PM"),

                DurationId=durations.Single(d => d.Time == 30).DurationId
            },
            new Lesson
            {
                LessonName="Introduction to Paino",
                LessonYear=1,
                LessonTerm=1,
                LessonDate=Days.Thursday,
                LessonTime=DateTime.Parse("11 AM"),
                TutorId=tutors.Single(t => t.LastName == "Zhang").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Paino").InstrumentId,
                DurationId=durations.Single(d => d.Time == 60).DurationId
            },
            new Lesson
            {
                LessonName="Master Flute",
                LessonYear=3,
                LessonTerm=1,
                LessonDate=Days.Monday,
                LessonTime=DateTime.Parse("2 PM"),
                TutorId=tutors.Single(t => t.LastName == "Zhang").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Flute").InstrumentId,
                DurationId=durations.Single(d => d.Time == 30).DurationId
            },
            new Lesson
            {
                LessonName="Introduction to Saxophone",
                LessonYear=1,
                LessonTerm=2,
                LessonDate=Days.Tuesdat,
                LessonTime=DateTime.Parse("9 AM"),
                TutorId=tutors.Single(t => t.LastName == "Olive").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Saxophone").InstrumentId,
                DurationId=durations.Single(d => d.Time == 45).DurationId
            },
            new Lesson
            {
                LessonName="Cello in practice",
                LessonYear=2,
                LessonTerm=2,
                LessonDate=Days.Friday,
                LessonTime=DateTime.Parse("2 PM"),
                TutorId=tutors.Single(t => t.LastName == "Bulo").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Cello").InstrumentId,
                DurationId=durations.Single(d => d.Time == 60).DurationId
            },
            new Lesson
            {
                LessonName="Creative Gituar",
                LessonYear=2,
                LessonTerm=2,
                LessonDate=Days.Wednesday,
                LessonTime=DateTime.Parse("1 PM"),
                TutorId=tutors.Single(t => t.LastName == "Olive").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Guitar").InstrumentId,
                DurationId=durations.Single(d => d.Time == 60).DurationId
            },
            new Lesson
            {
                LessonName="Introduction to Harp",
                LessonYear=1,
                LessonTerm=1,
                LessonDate=Days.Thursday,
                LessonTime=DateTime.Parse("1 PM"),
                TutorId=tutors.Single(t => t.LastName == "Olive").TutorId,
                InstrumentId=instruments.Single(i => i.InstrumentName == "Harp").InstrumentId,
                DurationId=durations.Single(d => d.Time == 30).DurationId
            }
            };
            foreach (Lesson l in lessons)
            {
                context.Lesson.Add(l);
            }
            context.SaveChanges();

            var LessonLists = new LessonList[]
            {
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Alexander").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Harp").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Alexander").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Cello in practice").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Alexander").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Creative Gituar").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Anand").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Master Flute").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Anand").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Cello in practice").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Barzdukas").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Harp").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Li").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Harp").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Justice").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Cornet").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Justice").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Harp").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Norman").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Cello in practice").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Norman").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Paino").LessonId
            },
            new LessonList
            {
                StudentId= students.Single(s => s.LastName == "Olivetto").StudentId,
                LessonId= lessons.Single(l => l.LessonName == "Introduction to Harp").LessonId
            },
            };
            foreach (LessonList e in LessonLists)
            {
                context.LessonList.Add(e);
            }
            context.SaveChanges();

            
        }
    }
}