using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }

        [Display(Name = "Instrument")]
        public string InstrumentType { get; set; }

    }
}
