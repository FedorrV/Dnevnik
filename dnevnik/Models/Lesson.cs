using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dnevnik.Models
{
    public class Lesson
    {
        public int? fkTeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int? fkSubjectId { get; set; }
        public Subject Subject { get; set; }
        public int LessonId { get; set; }
        public DateTime dateLesson { get; set; }
        public string timeLesson { get; set; }
        
        
        
    }
}