using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnevnik.Models;
namespace dnevnik.Controllers
{
    public class TeacherController : Controller
    {
        private shoolJournalEntities db;
        public TeacherController()
        {
            db = new shoolJournalEntities();
        }

        // GET: Teacher
        public ActionResult Grades()
        {
            
            List<Grades> grades = db.Grades.ToList();
            //for (int i=0;i < grades.Count();i++) {
            //    if(grades[i].Teachers == null)
            //    {
            //        grades[i].Teachers.firstname = "Отсутствует";
            //        grades[i].Teachers.lastname = "";
            //        grades[i].Teachers.patronymic = "";
            //        grades[i].Teachers.

            //    }        
            //}
           
            return View("~/Views/Teacher/Grades.cshtml", grades);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}