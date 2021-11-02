using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIT339_Assignment_1.Models
{
    public enum GenderType
    {
        Female,
        Male,
        Other
    }
    public class Instructor
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string IFullName
        {
            get { return FirstName + " " + LastName; }
        }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
    }

}
