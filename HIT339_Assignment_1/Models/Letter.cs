using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIT339_Assignment_1.Models
{
    public enum PaymentType
    {
        Paid,
        NotPaid
    }
    public class Letter
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        [Display(Name = "Student Details")]
        public string StudentDetails { get; set; }

        public PaymentType Payment { get; set; }

        public string Reference { get; set; }

        [Display(Name = "Outstanding Amount")]
        public float Cost { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "Account Name")]
        [Required]
        public string AccountName { get; set; }
        [Display(Name = "Account Number")]
        [Required]
        public int AccountNumber{ get; set; }
        [Display(Name = "BSB Number")]
        [Required]
        public int BSB{ get; set; }
        [Required]
        public string Signature { get; set; }


        public virtual Student Student { get; set; }

    }
}
