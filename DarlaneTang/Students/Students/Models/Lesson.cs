using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        
        [ForeignKey("Tutor")]
        public int TutorId { get; set; }

        [ForeignKey("Instrument")]
        public int InstrumentId { get; set; }

        [ForeignKey("Duration")]
        public int DurationId { get; set; }

        public Term Term { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="When")]
        public DateTime TimeYear { get; set; }

        [Display(Name = "PAID/NOT PAID")]
        public Boolean Paid { get; set; }

        public virtual Student Student { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual Instrument Instrument { get; set; }
        public virtual Letter Letter { get; set; }

    } 
    public enum Term
    {
       Term1,
       Term2,
       Term3,
       Term4
    }
}
