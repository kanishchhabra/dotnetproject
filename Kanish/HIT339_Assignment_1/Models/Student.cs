using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HIT339_Assignment_1.Models
{


    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string Reference
        {
            get { return Id + " " + FirstName + " " + LastName; }
        }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public GenderType Gender { get; set; }

        [Display(Name = "Parent/Guardian Name")]
        public string ParentGuardianName { get; set; }

        [Display(Name = "Billing Email")]
        [DataType(DataType.EmailAddress)]
        public string PaymentEmailAddress { get; set; }

        [Display(Name = "Billing Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PaymentPhoneNumber { get; set; }

        public override string ToString()
        {
            return Id + " - " + FirstName + " " + LastName + " - " + Age;
        }
    }
}