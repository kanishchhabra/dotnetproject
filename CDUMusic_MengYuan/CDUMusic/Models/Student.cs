using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDUMusic.Models
{
    public enum GenderType
    {
        Male,
        Female,
        Nonbinary
    }

    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(400)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        

        [Required]
        public GenderType Gender { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Parent Name")]
        public string ParentName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Payment Email")]
        public string PaymentEmail { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Payment Contact")]
        public string PaymentContact { get; set; }

        public ICollection<LessonList> LessonLists{ get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }

        //calculate age (should work)
        public int Age { 
            get 
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(DateOfBirth.ToString("yyyyMMdd"));
                return (now - dob) / 10000;
                
            }
            set { }
        }

        public string StudentName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }

}