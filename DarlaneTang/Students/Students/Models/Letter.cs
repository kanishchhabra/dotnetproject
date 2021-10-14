using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Letter
    {
        public int LetterId { get; set; }

        [ForeignKey("Lesson")]
        [Display(Name = "Lesson ID")]
        public int LessonId { get; set;}

        public Bank Bank { get; set; }
        public string ReferenceNo { get; set; }

        public string Comment { get; set; }
        [Display(Name = "Email")]
        public string SigEmail { get; set; }

        [Display(Name = "Account Name")]
        public string AccName { get; set; }

        public int BSB { get; set; }

        [Display(Name = "Account Number")]
        public int AccNo { get; set; }

        public virtual Lesson Lesson { get; set; }

    }
    public enum Bank
    {
        MasterCard,
        Visa
    }
}
