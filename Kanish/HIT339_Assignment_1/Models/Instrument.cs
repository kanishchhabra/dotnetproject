using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment_1.Models
{
    public enum InstrumentType
    {
        Guitar,
        Piano,
        Trumpet, 
        Violin
    }
    public class Instrument
    {
        public int id { get; set; }
        public InstrumentType InstrumentName { get; set; }
    }
}
