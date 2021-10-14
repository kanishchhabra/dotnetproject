using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }

        [Display(Name = "First Name")]
        public string TFname { get; set; }

        [Display(Name = "Last Name")]
        public string TLname { get; set; }

        [Display(Name = "Tutor")]
        public string TFullName
        {
            get
            {
                return TFname + " " + TLname;
            }
        }
        [Display(Name="Phone Number"), Phone]
        public string TPhone { get; set; }
    }
}
