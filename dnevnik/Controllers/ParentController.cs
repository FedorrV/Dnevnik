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

        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}