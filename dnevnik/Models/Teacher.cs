using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dnevnik.Models
{
    public class Teacher
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string patromymic { get; set; }
        public DateTime dateBirth { get; set; }
        public string address { get; set; }
        public int? fkShoolId { get; set; }
        public Shool Shool { get; set; }
        public int? fkGradeId { get; set; }
        //public Grade Grade { get; set; }
        public int TeacherId { get; set; }
        public string gender { get; set; }
    }
}