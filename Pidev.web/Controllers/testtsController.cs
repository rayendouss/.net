using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pidev.data;
using Pidev.service;

namespace Pidev.web.Controllers
{
    public class testtsController : Controller
    {
        timesheetService ts = new timesheetService();
        private Model1 db = new Model1();

        // GET: testts
        public ActionResult Index()
        {
              tp_jsf_timesheet time = new tp_jsf_timesheet();
              Employe ee = new Employe();
              var myModel = new testt();
              myModel.listA = ee.GetAll();
           
             // ts.Add(tp_jsf_timesheet);
              return View(myModel);

          /*  IEnumerable<tp_jsf_employe> list = ts.GetAll();*/

        }

        // GET: testts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testt testt = db.testts.Find(id);
            if (testt == null)
            {
                return HttpNotFound();
            }
            return View(testt);
        }

        // GET: testts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id")] testt testt)
        {
            if (ModelState.IsValid)
            {
                db.testts.Add(testt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testt);
        }

        // GET: testts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testt testt = db.testts.Find(id);
            if (testt == null)
            {
                return HttpNotFound();
            }
            return View(testt);
        }

        // POST: testts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id")] testt testt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testt);
        }

        // GET: testts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            testt testt = db.testts.Find(id);
            if (testt == null)
            {
                return HttpNotFound();
            }
            return View(testt);
        }

        // POST: testts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            testt testt = db.testts.Find(id);
            db.testts.Remove(testt);
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
