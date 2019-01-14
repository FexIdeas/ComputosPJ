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
    public class EscuelasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /Escuelas/
        public ActionResult Index()
        {
            var escuela = db.Escuela.Include(e => e.Circuito);
            return View(escuela.ToList());
        }

        // GET: /Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // GET: /Escuelas/Create
        public ActionResult Create()
        {
            ViewBag.CircuitoID = new SelectList(db.Circuito, "ID", "Nombre");
            return View();
        }

        // POST: /Escuelas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,CircuitoID")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Escuela.Add(escuela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CircuitoID = new SelectList(db.Circuito, "ID", "Nombre", escuela.CircuitoID);
            return View(escuela);
        }

        // GET: /Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            ViewBag.CircuitoID = new SelectList(db.Circuito, "ID", "Nombre", escuela.CircuitoID);
            return View(escuela);
        }

        // POST: /Escuelas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,CircuitoID")] Escuela escuela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escuela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CircuitoID = new SelectList(db.Circuito, "ID", "Nombre", escuela.CircuitoID);
            return View(escuela);
        }

        // GET: /Escuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuela escuela = db.Escuela.Find(id);
            if (escuela == null)
            {
                return HttpNotFound();
            }
            return View(escuela);
        }

        // POST: /Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escuela escuela = db.Escuela.Find(id);
            db.Escuela.Remove(escuela);
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
