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
    public class tp_jsf_projectController : Controller
    {
        tacheService lt = new tacheService();
        Projet ps;
        public tp_jsf_projectController()
        {

            ps = new Projet();
        }

        // GET: tp_jsf_project
        public ActionResult Index()
        {
            return View(ps.GetAll().ToList());
        }
        public ActionResult Listtache2()
        {


            return View();
        }
        
        public ActionResult Listtache(int id)
        {
          //  IEnumerable<tp_jsf_tache> tt = lt.Listtacheparprojet(id);

        
            return View(lt.Listtacheparprojet(id));
        }

        // GET: tp_jsf_project/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_project tp_jsf_project = ps.GetById(id);
            if (tp_jsf_project == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_project);
        }

        // GET: tp_jsf_project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tp_jsf_project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idp,descp,endDate,nomp,startDate")] tp_jsf_project tp_jsf_project)
        {
            if (ModelState.IsValid)
            {
                ps.Add(tp_jsf_project);
                ps.Commit();
                return RedirectToAction("Index");
            }

            return View(tp_jsf_project);
        }

        // GET: tp_jsf_project/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tp_jsf_project m = ps.GetById(id);
            tp_jsf_project M1 = new tp_jsf_project()
            {
                descp = m.descp,
                endDate = m.endDate,
                nomp = m.nomp,
                startDate = m.startDate,
          
            };
            if (m == null)
                return HttpNotFound();


            return View(M1);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tp_jsf_project m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    tp_jsf_project p = ps.GetById(id);

                    p.descp = m.descp;
                    p.endDate = m.endDate;
                    p.nomp = m.nomp;
                    p.startDate = m.startDate;
          

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    ps.Update(p);
                    ps.Commit();
                    // Service.Dispose();
                    // ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", p.manager_U_ID);
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

        public ActionResult Delete1()
        {

            return View();
        }


        // GET: tp_jsf_project/Delete/5

        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_project tp_jsf_project = ps.GetById(id);
            if (tp_jsf_project == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_project);
        }

        // POST: tp_jsf_project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_project tp_jsf_project = ps.GetById(id);
            ps.Delete(tp_jsf_project);
            ps.Commit();
            return RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
