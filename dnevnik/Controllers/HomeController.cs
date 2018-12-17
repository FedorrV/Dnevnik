using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dnevnik.Models;
using System.Configuration;
using System.Data.Entity;
namespace dnevnik.Controllers
{
    public class HomeController : Controller
    {
        private shoolJournalEntities db;
        
        public HomeController()
        {
            db = new shoolJournalEntities();
        }

        // DnevnikContext dbContext = new DnevnikContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        public ActionResult Index()
        {
            List <Students> Students = db.Students.ToList();
            // возвращаем представление
            return View();
        }
       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}