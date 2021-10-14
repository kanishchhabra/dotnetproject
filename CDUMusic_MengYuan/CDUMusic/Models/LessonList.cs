using System;


namespace CDUMusic.Models
{
    public class LessonList
    {
        public int LessonListId { get; set; }
        public int StudentId { get; set; }
        public int LessonId { get; set; }

        public Student Student { get; set; }
        public Lesson Lesson { get; set; }

        public bool isPaid { get; set; } = false;
    }
}
