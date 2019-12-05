using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pidev.data;
using Pidev.service;

namespace Pidev.web.Controllers
{
    public class EmployeTimeController : Controller
    {
        private Model1 db = new Model1();
        timesheetService ts = new timesheetService();
        tacheService ta = new tacheService();
        Projet p = new Projet();
            // GET: EmployeTime
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListTime()
        {
           
            int p = (int)Session["id"];
            
            return View(ts.Listtimeparemp(p));
        }
        
        
      
        public ActionResult ListProjet(int id)
        {
            
            return View(p.Listpr(id));
        }
      
        public ActionResult ListTache(int id)
        {
            
            return View(ta.Listtacheparprojet(id));
        }

        // GET: EmployeTime/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_timesheet tp_jsf_timesheet = db.tp_jsf_timesheet.Find(id);
            if (tp_jsf_timesheet == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_timesheet);
        }

        // GET: EmployeTime/Create
        public ActionResult Create()
        {
            var p = Session["id"];
            return View(p);
           
        }

        // POST: EmployeTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idT,EtatTache,NbreConge,NbreHeureTRavJour,NbreHeureTRavS,etat,idEmploye,idpfk")] tp_jsf_timesheet tp_jsf_timesheet)
        {
            if (ModelState.IsValid)
            {
                db.tp_jsf_timesheet.Add(tp_jsf_timesheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tp_jsf_timesheet);
        }

        // GET: EmployeTime/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_timesheet tp_jsf_timesheet = db.tp_jsf_timesheet.Find(id);
            if (tp_jsf_timesheet == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_timesheet);
        }

        // POST: EmployeTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idT,EtatTache,NbreConge,NbreHeureTRavJour,NbreHeureTRavS,etat,idEmploye,idpfk")] tp_jsf_timesheet tp_jsf_timesheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp_jsf_timesheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp_jsf_timesheet);
        }

        // GET: EmployeTime/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_timesheet tp_jsf_timesheet = db.tp_jsf_timesheet.Find(id);
            if (tp_jsf_timesheet == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_timesheet);
        }

        // POST: EmployeTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_timesheet tp_jsf_timesheet = db.tp_jsf_timesheet.Find(id);
            db.tp_jsf_timesheet.Remove(tp_jsf_timesheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
