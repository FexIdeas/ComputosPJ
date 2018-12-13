using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputosPJ.Models;

namespace ComputosPJ.Controllers
{
    public class JuntasDepartamentalesController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /JuntasDepartamentales/
        public ActionResult Index()
        {
            var juntadepartamental = db.JuntaDepartamental.Include(j => j.Municipio);
            return View(juntadepartamental.ToList());
        }

        // GET: /JuntasDepartamentales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JuntaDepartamental juntaDepartamental = db.JuntaDepartamental.Find(id);
            if (juntaDepartamental == null)
            {
                return HttpNotFound();
            }
            return View(juntaDepartamental);
        }

        // GET: /JuntasDepartamentales/Create
        public ActionResult Create()
        {
            ViewBag.MunicipioID = new SelectList(db.Municipio, "ID", "Nombre");
            return View();
        }

        // POST: /JuntasDepartamentales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,MunicipioID")] JuntaDepartamental juntaDepartamental)
        {
            if (ModelState.IsValid)
            {
                db.JuntaDepartamental.Add(juntaDepartamental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipioID = new SelectList(db.Municipio, "ID", "Nombre", juntaDepartamental.MunicipioID);
            return View(juntaDepartamental);
        }

        // GET: /JuntasDepartamentales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JuntaDepartamental juntaDepartamental = db.JuntaDepartamental.Find(id);
            if (juntaDepartamental == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipioID = new SelectList(db.Municipio, "ID", "Nombre", juntaDepartamental.MunicipioID);
            return View(juntaDepartamental);
        }

        // POST: /JuntasDepartamentales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,MunicipioID")] JuntaDepartamental juntaDepartamental)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juntaDepartamental).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipioID = new SelectList(db.Municipio, "ID", "Nombre", juntaDepartamental.MunicipioID);
            return View(juntaDepartamental);
        }

        // GET: /JuntasDepartamentales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JuntaDepartamental juntaDepartamental = db.JuntaDepartamental.Find(id);
            if (juntaDepartamental == null)
            {
                return HttpNotFound();
            }
            return View(juntaDepartamental);
        }

        // POST: /JuntasDepartamentales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JuntaDepartamental juntaDepartamental = db.JuntaDepartamental.Find(id);
            db.JuntaDepartamental.Remove(juntaDepartamental);
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
