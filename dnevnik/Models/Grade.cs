using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dnevnik.Models
{
    public class Grade
    {
        
        public int GradeId { get; set; }
        public string name { get; set; }
        public int? fkShoolId { get; set; }
        public Shool Shool { get; set; }
        
        public int? fkTeacherId { get; set;}
        public Teacher Teacher { get; set;}
    }
}