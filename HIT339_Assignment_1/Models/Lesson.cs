using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HIT339_Assignment_1.Models
{
    public enum TermType
    {
       Term1 = 1,
       Term2 = 2,
       Term3 = 2,
       Term4 = 4
    }
    public enum SemesterType
    {
        Semester1 = 1,
        Semester2 = 2
    }
    public enum LessonDurationType
    {
        HalfHour = 30,
        QuarterToHour = 45,
        Hour = 60
    }
    public class Lesson
    {
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Student")]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }
       
        [Required]
        [ForeignKey("Instructor")]
        [Display(Name = "Instructor ID")]
        public int InstructorID { get; set; }
        
        [Required]
        [ForeignKey("Instrument")]
        [Display(Name = "Instrument ID")]
        public int InstrumentID { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public SemesterType Semester { get; set; }

        [Required]
        [Display(Name = "Term")]
        public TermType Term { get; set; }

        [Required]
        [Display(Name = "Lesson Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LessonDate { get; set; }

        [Display(Name = "Year & Term")]
        public string YearAndTerm
        {
            get { return LessonDate.Year + " " + Term; }
        }

        [Required]
        [Display(Name = "Lesson Duration")]
        public LessonDurationType LessonDuration { get; set; } 

        public Double  Cost {
            get { 
                return (Double)LessonDuration / 60 * 50;
            }
        }

        public Boolean Paid { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Student Student { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}
