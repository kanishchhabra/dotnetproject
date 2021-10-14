using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CDUMusic.Models
{
    public class Tutor
    {
        public int TutorId { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(400)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }

        //One Tutor leaches many Lessons
        public ICollection<Lesson> Lessons { get; set; }

    }
}
