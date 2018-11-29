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
        public ActionResult Grades(int gradeId)
        {
            Grades grade = db.Grades.Find(gradeId);
            return View("~/Views/Shool/Grades.cshtml", grade);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}