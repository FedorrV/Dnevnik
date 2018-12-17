using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnevnik.Models;
//using System.Data.Entity;
namespace dnevnik.Controllers
{
    public class ParentController : Controller
    {
        private shoolJournalEntities db;
        public ParentController()
        {
            db = new shoolJournalEntities();
        }

        public ActionResult Ratings()
        {
            List<Grades> grades = db.Grades.ToList();
            return View(grades);
        }

        class ratingItem
        {
            public string subjectName { get; set; }
            public string teacherFullname { get; set; }
            public string dateLesson { get; set; }
            public string timeLesson { get; set; }
            public int rating { get; set; }
        }

        [HttpGet]
        public JsonResult getRatings(int? studentId)
        {
            var arrRatings = new List<ratingItem>();
            List<Ratings> ratings = db.Ratings.Where(g => g.StudentId == studentId).ToList();
            for (int i = 0; i < ratings.Count(); i++)
            {
                arrRatings.Add(new ratingItem
                {
                    subjectName = ratings[i].Lessons.Subjects.name,
                    teacherFullname = ratings[i].Lessons.Teachers.lastname + " " + ratings[i].Lessons.Teachers.firstname + " " + ratings[i].Lessons.Teachers.patronymic,
                    dateLesson = ratings[i].Lessons.dateLesson.ToString().Substring(0,10),
                    timeLesson= ratings[i].Lessons.timeLesson,
                    rating= ratings[i].rating??4
                });
            }
            return Json(arrRatings, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}