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
    public class tp_jsf_tacheController : Controller
    {
        Projet p = new Projet();
        tacheService ts;
        public tp_jsf_tacheController()
        {

            ts = new tacheService();
        }
        // GET: tp_jsf_tache
        public ActionResult Index()
        {
            return View(ts.GetAll().ToList());
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tp_jsf_tache m = ts.GetById(id);
            tp_jsf_tache M1 = new tp_jsf_tache()
            {
                desct = m.desct,
                StartDate = m.StartDate,
                EndDate = m.EndDate,
               nomt= m.nomt,


            };
            if (m == null)
                return HttpNotFound();


            return View(M1);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tp_jsf_tache m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    tp_jsf_tache p = ts.GetById(id);

                    p.desct = m.desct;
                    p.StartDate = m.StartDate;
                    p.EndDate = m.EndDate;
                    p.nomt = m.nomt;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    ts.Update(p);
                    ts.Commit();
                 
                    return RedirectToAction("Index");
                }
                // TODO: Add delete logic here
                return View(m);

            }
            catch
            {
                return View();
            }
        }
       
        
        // GET: tp_jsf_tache/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(p.GetAll(), "idp", "nomp");
            return View();
        }

        // POST: tp_jsf_tache/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idt,EndDate,StartDate,desct,nomt,employes_id,timesheets_idT,id")] tp_jsf_tache tp_jsf_tache)
        {
            if (ModelState.IsValid)
            {
                ts.Add(tp_jsf_tache);
                ts.Commit();
                ViewBag.idp = new SelectList(p.GetAll(), "idp", "nomp", tp_jsf_tache.idt);
                return RedirectToAction("Index");
            }

            return View(tp_jsf_tache);
        }
        /*
        // GET: tp_jsf_tache/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_tache tp_jsf_tache = db.tp_jsf_tache.Find(id);
            if (tp_jsf_tache == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_tache);
        }
       
        // POST: tp_jsf_tache/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idt,EndDate,StartDate,desct,nomt,employes_id,projects_idp,timesheets_idT,id,timesheets_statut")] tp_jsf_tache tp_jsf_tache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp_jsf_tache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp_jsf_tache);
        }
         */
        // GET: tp_jsf_tache/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_tache tp_jsf_tache = ts.GetById(id);
            if (tp_jsf_tache == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_tache);
        }

        // POST: tp_jsf_tache/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_tache tp_jsf_tache = ts.GetById(id);
            ts.Delete(tp_jsf_tache);
            ts.Commit();
            return RedirectToAction("Index");
        }
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
