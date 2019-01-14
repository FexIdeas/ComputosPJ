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
    public class CircuitosController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /Circuitos/
        public ActionResult Index()
        {
            var circuito = db.Circuito.Include(c => c.JuntaDepartamental);
            return View(circuito.ToList());
        }

        // GET: /Circuitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuito.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            return View(circuito);
        }

        // GET: /Circuitos/Create
        public ActionResult Create()
        {
            ViewBag.JuntaDepartamentalID = new SelectList(db.JuntaDepartamental, "ID", "Nombre");
            return View();
        }

        // POST: /Circuitos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,JuntaDepartamentalID")] Circuito circuito)
        {
            if (ModelState.IsValid)
            {
                db.Circuito.Add(circuito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JuntaDepartamentalID = new SelectList(db.JuntaDepartamental, "ID", "Nombre", circuito.JuntaDepartamentalID);
            return View(circuito);
        }

        // GET: /Circuitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuito.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            ViewBag.JuntaDepartamentalID = new SelectList(db.JuntaDepartamental, "ID", "Nombre", circuito.JuntaDepartamentalID);
            return View(circuito);
        }

        // POST: /Circuitos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,JuntaDepartamentalID")] Circuito circuito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circuito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JuntaDepartamentalID = new SelectList(db.JuntaDepartamental, "ID", "Nombre", circuito.JuntaDepartamentalID);
            return View(circuito);
        }

        // GET: /Circuitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuito circuito = db.Circuito.Find(id);
            if (circuito == null)
            {
                return HttpNotFound();
            }
            return View(circuito);
        }

        // POST: /Circuitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circuito circuito = db.Circuito.Find(id);
            db.Circuito.Remove(circuito);
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
