using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Pidev.data;
using Pidev.service;

namespace Pidev.web.Controllers
{
    public class tp_jsf_reclamationController : Controller
    {
        ReclamationService rc = new ReclamationService();
        private Model1 db = new Model1();
        Employe em = new Employe();

        // GET: tp_jsf_reclamation

        public ActionResult Index()
        {
            return View(rc.Listrec((int)Session["id"]));
        }

        // GET: tp_jsf_reclamation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }
        public ActionResult SendMail()
        {
            var fromAddress = new MailAddress("mohamedrayane.douss@esprit.tn", "Reclamation");
            var toAddress = new MailAddress("mohamedrayane.douss@esprit.tn", " Reclamation");
            const string fromPassword = "fcrealmadrid";
            string subject = "From"+Session["nom"]; //your subject line
            string body = "Reclamation ";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", //example
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body

            })
            {
                try
                {
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    Debug.WriteLine("mail Send");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("*****************************" + ex.ToString());
                }

            }
            return null;
        }
    

        // GET: tp_jsf_reclamation/Create
        public ActionResult Create()
        {
            int p = (int)Session["id"];
            ViewBag.emps_id = new SelectList(em.GetAll(), "id", "nom");
            ViewBag.idemp = p;
            return View();
        }

        // POST: tp_jsf_reclamation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRec,description,idemp,name,rep,emps_id")] tp_jsf_reclamation tp_jsf_reclamation)
        {
            if (ModelState.IsValid)
                if (ModelState.IsValid)
                {
                   
                    rc.Add(tp_jsf_reclamation);
                  
                    rc.Commit();
                    SendMail();
                    int p = (int)Session["id"];
                    ViewBag.emps_id = new SelectList(em.GetAll(), "id", "nom");
                    ViewBag.idemp = p;
                    return RedirectToAction("Index");
                }

            return View(tp_jsf_reclamation);
        }

        // GET: tp_jsf_reclamation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = db.tp_jsf_reclamation.Find(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }

        // POST: tp_jsf_reclamation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRec,description,idemp,name,rep,emps_id")] tp_jsf_reclamation tp_jsf_reclamation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tp_jsf_reclamation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tp_jsf_reclamation);
        }

        // GET: tp_jsf_reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tp_jsf_reclamation tp_jsf_reclamation = rc.GetById(id);
            if (tp_jsf_reclamation == null)
            {
                return HttpNotFound();
            }
            return View(tp_jsf_reclamation);
        }

        // POST: tp_jsf_project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tp_jsf_reclamation tp_jsf_reclamation = rc.GetById(id);
            rc.Delete(tp_jsf_reclamation);
            rc.Commit();
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



