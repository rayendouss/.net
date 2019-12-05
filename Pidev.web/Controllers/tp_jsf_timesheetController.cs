using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Pidev.data;
using Pidev.service;

namespace Pidev.web.Controllers
{
    public class tp_jsf_timesheetController : Controller
    {
        timesheetService ts;
        Employe em = new Employe();
        Projet pr = new Projet();
        public ActionResult ImportExcel()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Excel excel = new Excel();
            excel.export(ts.GetAll());

            excel.saveAs(path + "/Timesheet");
            excel.close();
            return View();
        }

        public tp_jsf_timesheetController()
        {

            ts = new timesheetService();
        }
        // GET: tp_jsf_timesheet
        public ActionResult Index()
        {
            return View(ts.GetAll().ToList());
        }

        public ActionResult Details()
        {
            return View();
        }
        // GET: tp_jsf_timesheet/Details/5
        [HttpPost]
        /*  public ActionResult Details(int id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
            IEnumerable<tp_jsf_timesheet> tt=<tp_jsf_timesheet> tp_jsf_timesheet;
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
            
            if (tp_jsf_timesheet == null)
              {
                  return HttpNotFound();
              }
              
              return View(tp_jsf_timesheet);
          }
          */


        // POST: tp_jsf_timesheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        public ActionResult Create2()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.idEmploye = new SelectList(em.GetAll(), "id", "nom");
            ViewBag.idpfk = new SelectList(pr.GetAll(), "idp", "nomp");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idT,EtatTache,NbreConge,NbreHeureTRavJour,NbreHeureTRavS,idEmploye,idp,idpfk,etat")] tp_jsf_timesheet tp_jsf_timesheet)
        {
            tp_jsf_timesheet timesheet = new tp_jsf_timesheet();
            // Employe ee = new Employe();
            //var myModel = new testt();
            // myModel.listA = ee.GetAll();
            if (ModelState.IsValid)
            {

              

                ts.Add(tp_jsf_timesheet);
                ts.Commit();
                ViewBag.idEmploye = new SelectList(em.GetAll(), "id", "nom", tp_jsf_timesheet.idEmploye);
                ViewBag.idpfk = new SelectList(pr.GetAll(), "idp", "nomp", tp_jsf_timesheet.idpfk);
                return RedirectToAction("Index");
            }



            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
            if (tp_jsf_timesheet == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_timesheet);
        }

        // POST: tp_jsf_timesheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_timesheet tp_jsf_timesheet = ts.GetById(id);
            ts.Delete(tp_jsf_timesheet);
            ts.Commit();
            return RedirectToAction("Index");
        }

        // GET: tp_jsf_timesheet/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tp_jsf_timesheet m = ts.GetById(id);
            tp_jsf_timesheet M1 = new tp_jsf_timesheet()
            {
                EtatTache = m.EtatTache,
                NbreConge = m.NbreConge,
                NbreHeureTRavJour = m.NbreHeureTRavJour,
                NbreHeureTRavS = m.NbreHeureTRavS,
                idpfk = m.idpfk,
                idEmploye = m.idEmploye,



            };
            if (m == null)
                return HttpNotFound();

            //   ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName");
            return View(M1);
        }

        // POST: tp_jsf_timesheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, tp_jsf_timesheet m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    tp_jsf_timesheet p = ts.GetById(id);
                    p.EtatTache = m.EtatTache;
                    p.NbreConge = m.NbreConge;
                    p.NbreHeureTRavJour = m.NbreHeureTRavJour;
                    p.NbreHeureTRavS = m.NbreHeureTRavS;
                    p.idpfk = m.idpfk;
                    p.idEmploye = m.idEmploye;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    ts.Update(p);
                    ts.Commit();
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
    }
}
