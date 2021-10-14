using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDUMusic.Models
{
    public enum InstrumentType
    {
        Brass,
        Keyboard,
        Orchestra,
        Percussion,
        String,
        Woodwind
    }

    public class Instrument
    {
        public int InstrumentId { get; set; }
        

        [Required, StringLength(200)]
        [DataType(DataType.Text)]
        [Display(Name = "Instrument Name")]
        public string InstrumentName { get; set; }

        [Required]
        [Display(Name = "Type")]
        public InstrumentType InsType { get; set; }

        //One Instrucment can be used in many Lessons
        public ICollection<Lesson> Lessons { get; set; }

    }
}
