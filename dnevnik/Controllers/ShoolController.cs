using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnevnik.Models;

namespace dnevnik.Controllers
{
    public class ShoolController : Controller
    {
        private shoolJournalEntities db;
        public ShoolController()
        {
            db = new shoolJournalEntities();
        }

        public ActionResult allGrades()
        {
            List<Grades> grades = db.Grades.ToList();
            return View(grades);
        }

        [HttpGet]
        public ActionResult Grades(int?gradeId)
        {
            if (gradeId == null)
                return HttpNotFound();
            Grades grade = db.Grades.FirstOrDefault(gr=>gr.GradeId==gradeId);
            if (grade != null)
                return View(grade);
            else
                return HttpNotFound();
        }

        public ActionResult allTeachers()
        {
            List<Teachers> teachers = db.Teachers.ToList();
            return View(teachers);
        }

        [HttpGet]
        public ActionResult Teachers(int?teacherId)
        {
            if (teacherId == null)
                return HttpNotFound();
            Teachers teacher = db.Teachers.FirstOrDefault(t=>t.TeacherId==teacherId);
            if (teacher != null)
                return View(teacher);
            else
                return HttpNotFound();
        }

        public ActionResult Students(int? studentId)
        {
            if(studentId == null)
                return HttpNotFound();
            Students student = db.Students.FirstOrDefault(st=>st.StudentId==studentId);
            if (student != null)
                return View(student);
            else
                return HttpNotFound();
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}