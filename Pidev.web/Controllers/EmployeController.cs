
using Pidev.data;
using Pidev.service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.web.Controllers
{
    public class EmployeController : Controller
    {
        public Employe e;
        public EmployeController()
        {
            e = new Employe();
        }
        // GET: Employe
        public ActionResult IndexEmploye()
        {
            return View(e.GetAll().ToList());
        }

        // GET: Employe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
       

        // GET: Employe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tp_jsf_employe e)
        {
            Debug.WriteLine("b");
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.PostAsJsonAsync<tp_jsf_employe>("PI_GL-web/api/users", e).Result;
            
            //    tp_jsf_employe eml = new tp_jsf_employe();
            if (response.IsSuccessStatusCode)
            { 

                return RedirectToAction("accEmp");

            }


            return RedirectToAction("Create");


        }

        public ActionResult Edit(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tp_jsf_employe m = e.GetById(id);
            tp_jsf_employe M1 = new tp_jsf_employe()
            {
                nom = m.nom,
                isActif = m.isActif,
                password = m.password,
                prenom = m.prenom,
                role = m.role,
                email = m.email,


            };
            if (m == null)
                return HttpNotFound();

       
            return View(M1);
        }

        // POST: Mission/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tp_jsf_employe m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    tp_jsf_employe p = e.GetById(id);

                    p.nom = m.nom;
                    p.isActif = m.isActif;
                    p.password = m.password;
                    p.prenom = m.prenom;
                    p.role = m.role;
                    p.email = m.email;

                    if (p == null)
                        return HttpNotFound();

                    Console.WriteLine("updaaaaaaaaaaaate");
                    e.Update(p);
                    e.Commit();
                    // Service.Dispose();
                   // ViewBag.manager_U_ID = new SelectList(es.GetAll(), "U_ID", "U_FirstName", p.manager_U_ID);
                    return RedirectToAction("accEmp");
                }
                // TODO: Add delete logic here
                return View(m);

            }
            catch
            {
                return View();
            }
        }
       


        // GET: Employe/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("PI_GL-web/api/users/del?id=" + id).Result;
            tp_jsf_employe eml = new tp_jsf_employe();
            if (response.IsSuccessStatusCode)
            {

                eml = response.Content.ReadAsAsync<tp_jsf_employe>().Result;

            }
            else
            {
                ViewBag.project = "erreur";
            }

            return View(eml);
        }

        // POST: Employe/Delete/5
       [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/");

                // TODO: Add insert logic here
                client.DeleteAsync("PI_GL-web/api/users/del?id=" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("accEmp");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ndex2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ndex2(tp_jsf_employe e)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PI_GL-web/api/users/login?email=" + e.email + "&password=" + e.password).Result;
            if (response.IsSuccessStatusCode)
            {
                // timesheetService ts;

                tp_jsf_employe a = response.Content.ReadAsAsync<tp_jsf_employe>().Result;
                Session["id"] = a.id;
                Session["nom"] = a.nom;
                if (a.role.Equals("ADMINISTRATEUR"))
                {

                    // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Emp>>().Result;
                    return RedirectToAction("acc");
                }
                else
                {
                    return RedirectToAction("Index", "EmployeTime");
                }
            }
            else
            {
                return RedirectToAction("ndex2");
            }
        }
        public ActionResult acc()
        {
            return View();
        }
        [HttpGet]
        public ActionResult accEmp()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("PI_GL-web/api/users/all").Result;
           
            if (response.IsSuccessStatusCode)
            {

               ViewBag.result = response.Content.ReadAsAsync<IEnumerable<tp_jsf_employe>>().Result;
                return View();
            }
            else
            {
                return ViewBag.result = "error";
            }
        }
        
     
    }
}
