using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDUMusic.Models
{

    public class Duration
    {
        public int DurationId { get; set; }
        
        [Required]
        [Display(Name = "Time(minute)")]
        public int Time { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:$#.##}")]
        public float? Cost { get; set; }

        //One Duration shared in many Lessons
        public ICollection<Lesson> Lessons { get; set; }

    }
}
