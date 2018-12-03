using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnevnik.Models;
using System.Data.Entity;

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
        public ActionResult addGrade()
        {
            List<Teachers> listTeachers = db.Teachers.Where(t => t.GradeId == null).ToList();

            var viewList = listTeachers.Select(p => new { p.TeacherId, Name = $"{p.lastname} {p.firstname} {p.patronymic}" }).ToList();

            SelectList ListTeachers = new SelectList(viewList, "TeacherId", "Name");
            ViewBag.ListTeachers = ListTeachers;
            return View();
        }

        [HttpPost]
        public ActionResult addGrade(Grades grade)
        {
            grade.ShoolId = 1;//пока в базе одна единстенная школа

            Teachers teach = db.Teachers.Find(grade.TeacherId);
            teach.GradeId = grade.GradeId;

            db.Entry(grade).State = EntityState.Added;
            db.Entry(teach).State = EntityState.Modified;
            db.SaveChanges();
            List<Grades> grades = db.Grades.ToList();
            return RedirectToAction("Grades", grades);
        }

        [HttpGet]
        public ActionResult DeleteGrade(int? gradeId)
        {
            if (gradeId == null)
                return HttpNotFound();
            Grades gr = db.Grades.FirstOrDefault(g => g.GradeId == gradeId);
            if (gr != null)
            {
                gr.Teachers.GradeId = null;
                db.Grades.Remove(gr);
                db.SaveChanges();

                List<Grades> grades = db.Grades.ToList();
                return RedirectToAction("Grades", grades);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult addStudent()
        {
            List<Grades> listGr = db.Grades.ToList();
            SelectList ListGrades = new SelectList(listGr, "GradeId", "name");
            ViewBag.ListGrades = ListGrades;
            return View();
        }

        [HttpPost]
        public ActionResult addStudent(Students student)
        {
            student.ShoolId = 1;
            db.Entry(student).State = EntityState.Added;
            db.SaveChanges();

            List<Grades> grades = db.Grades.ToList();
            return RedirectToAction("Grades", grades);
        }

        [HttpGet]
        public ActionResult deleteStudents(int? gradeId)
        {
            if (gradeId == null)
                return HttpNotFound();
            Grades gr = db.Grades.FirstOrDefault(g => g.GradeId == gradeId);
            if (gr == null)
                return HttpNotFound();
            List<Students> st = gr.Students.ToList();
            return View(st);

        }

        [HttpGet]
        public ActionResult deleteStudent(int studentid)
        {
            Students st = db.Students.Find(studentid);
            db.Students.Remove(st);
            db.SaveChanges();

            List<Students> sts = db.Grades.Find(st.GradeId).Students.ToList();
            return RedirectToAction("deleteStudent", sts);
        }

        public ActionResult Lessons()
        {
            List<Lessons> lessons = db.Lessons.ToList();
            return View(lessons);
        }


        public ActionResult addLesson()
        {
            List<Grades> listGrades = db.Grades.ToList();
            SelectList ListGrades = new SelectList(listGrades, "GradeId", "name");
            List<Subjects> listSubjects = db.Subjects.ToList();
            SelectList ListSubjects = new SelectList(listSubjects, "SubjectId", "name");
            ViewBag.ListGrades = ListGrades;
            ViewBag.ListSubjects = ListSubjects;
            return View();
        }

        [HttpPost]
        public ActionResult addLesson(Lessons lesson)
        {
            db.Entry(lesson).State = EntityState.Added;
            db.SaveChanges();
            List<Lessons> lessons = db.Lessons.ToList();
            return RedirectToAction("Lessons", lessons);
        }

        class TeacherItem
        {
            public string fullname { get; set; }
            public int TeacherId { get; set; }
        }

        [HttpGet]
        public JsonResult getTeachers(int SubjectId)
        {
        var arrTeachers = new List<TeacherItem>();
        List<Specialization> spec = db.Specialization.Where(sp => sp.SubjectId == SubjectId).ToList();
        for(int i=0;i< spec.Count(); i++)
            {
                arrTeachers.Add(new TeacherItem { fullname = spec[i].Teachers.lastname+" " + spec[i].Teachers.firstname + " " + spec[i].Teachers.patronymic,
                                                  TeacherId = spec[i].Teachers.TeacherId });
            }
        return Json(arrTeachers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult addRating(int? lessonId)
        {
            if (lessonId == null)
                return HttpNotFound();

            Lessons lesson = db.Lessons.FirstOrDefault(l=>l.LessonId==lessonId);
            if (lesson == null)
                return HttpNotFound();
            List<Students> students = db.Students.Where(s => s.GradeId == lesson.GradeId).ToList();
            var viewList = students.Select(p => new { p.StudentId, Name = $"{p.lastname} {p.firstname} {p.patronymic}" }).ToList();
            SelectList listStudents = new SelectList(viewList, "StudentId","Name");

            ViewBag.listStudents = listStudents;
            ViewBag.lessonId = lessonId;
            return View(lesson);
        }

        [HttpPost]
        public ActionResult addRating(Ratings rat)
        {
            db.Entry(rat).State = EntityState.Added;
            db.SaveChanges();
            List<Lessons> lessons = db.Lessons.ToList();
            return RedirectToAction("Lessons", lessons);
        }


        class StudentItem
        {
            public string fullname { get; set; }
            public int StudentId { get; set; }
        }

        [HttpGet]
        public JsonResult getStudents(int GradeId)
        {
            var arrStudents = new List<StudentItem>();
            List<Students> students = db.Students.Where(st => st.GradeId == GradeId).ToList();
            for (int i = 0; i < students.Count(); i++)
            {
                arrStudents.Add(new StudentItem
                {
                    fullname = students[i].lastname + " " + students[i].firstname + " " + students[i].patronymic,
                    StudentId = students[i].StudentId
                });
            }
            return Json(arrStudents, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public ActionResult EditGrades(int gradeId)
        //{
        //    Grades grade = db.Grades.FirstOrDefault(gr => gr.GradeId == gradeId);
        //    if (grade != null)
        //    {
        //        List<Teachers> listTeachers = db.Teachers.Where(t => t.GradeId == null).ToList();
        //        SelectList ListTeachers = new SelectList(listTeachers, "TeacherId", "lastname");
        //        ViewBag.ListTeachers = ListTeachers;
        //        return View(grade);
        //    }
        //    return HttpNotFound();
        //}

        //[HttpPost]
        //public ActionResult EditGrades(Grades grade)
        //{
        //    Grades gr = db.Grades.FirstOrDefault(g => g.GradeId == grade.GradeId);
        //    if (gr == null)
        //        return HttpNotFound();
        //    gr.name = grade.name;
        //    gr.TeacherId = grade.TeacherId;
        //    //gr.Teacher = db.Teachers.FirstOrDefault(t=>t.TeacherId==grade.TeacherId);
        //    db.Entry(gr).State = EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("EditGrades", new { gradeId = gr.GradeId });
        //}

        protected override void Dispose(bool disposing)
    {
        db.Dispose();
        base.Dispose(disposing);
    }
}
}