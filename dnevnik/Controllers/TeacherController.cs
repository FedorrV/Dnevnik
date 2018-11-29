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
            return View(grades);
        }

        [HttpGet]
        public ActionResult EditGrades(int gradeId)
        {
            Grades grade = db.Grades.FirstOrDefault(gr => gr.GradeId == gradeId);
            if(grade != null)
            {
                //List<Teachers> listTeachers = db.Teachers.ToList();

                SelectList ListTeachers = new SelectList(db.Teachers,"TeacherId","lastname");
                ViewBag.ListTeachers = ListTeachers;
                return View(grade);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditGrades(Grades grade)
        {
            Grades gr = grade;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}