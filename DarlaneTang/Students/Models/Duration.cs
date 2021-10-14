using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Duration
    {
        public int DurationId { set; get; }

        [Display(Name = "Duration (in minutes)")]
        public int DurationTime { set; get; }

        [DataType(DataType.Currency)]
        [Required]
        public int Cost { set; get; }
    }
}
