using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDUMusic.Models
{
    public enum Days
    {
        Monday,
        Tuesdat,
        Wednesday,
        Thursday,
        Friday
    }

    public class Lesson
    {

        public int LessonId { get; set; }

        [Required]
        [Display(Name = "Lesson")]
        public string LessonName { get; set; }

        //Many students enroll in one lesson
        public ICollection<LessonList> LessonLists{ get; set; }

        [DisplayFormat(NullDisplayText = "No tutor")]
        public int? TutorId { get; set; }
        //One tutor teaches one lesson
        public Tutor Tutor{ get; set; }

        [DisplayFormat(NullDisplayText = "No Instrument")]
        public int? InstrumentId { get; set; }
        //One instrucment in one lesson
        public Instrument Instrument { get; set; }

        [Required]
        [Range(1,5)]
        [Display(Name = "Year")]
        public int LessonYear { get; set; }

        [Required]
        [Display(Name = "Term")]
        public int LessonTerm { get; set; }

        //[Required, DataType(DataType.Date)]
        [Display(Name = "Days")]
        public Days LessonDate { get; set; }

        [Required, DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime LessonTime { get; set; }

        [DisplayFormat(NullDisplayText = "Duration not provided")]
        public int? DurationId { get; set; }
        //One Duration in one lesson
        public Duration Duration { get; set; }
    }
}
