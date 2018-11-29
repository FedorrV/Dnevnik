using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dnevnik.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int rating { get; set; }
        public int? fkLessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int? fkStudentId { get; set; }
        public Student Student { get; set; }
    }
}