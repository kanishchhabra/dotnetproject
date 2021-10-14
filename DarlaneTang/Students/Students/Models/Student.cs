using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(200,MinimumLength =2)]
        public string Fname { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(400)]
        public string Lname { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get
            {
                return Fname + " " + Lname;
            } 
        }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        //Calculated Age B)
        public int? Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - DOB.Year;
                if (DOB > now.AddYears(-age)) age--;
                return age;
            }
        }

        [Display(Name ="Gender")]
        public Gender StudentGender { get; set; }

        [Display(Name = "Parent or Guadian Name")]
        public string PGname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        //could change this to [Display(Name="Contact Number"),Phone]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Must be 10 numbers!")]
        public int ContactNo { get; set; }

    }


    public enum Gender
    {
        Female,
        Male,
        Other
    }
}
