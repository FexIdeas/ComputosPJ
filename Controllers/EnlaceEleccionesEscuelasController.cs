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
    public class EnlaceEleccionesEscuelasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /EnlaceEleccionesEscuelas/
        public ActionResult Index()
        {
            var enlaceeleccionescuela = db.EnlaceEleccionEscuela.Include(e => e.Eleccion).Include(e => e.Escuela);
            return View(enlaceeleccionescuela.ToList());
        }

        // GET: /EnlaceEleccionesEscuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionEscuela enlaceEleccionEscuela = db.EnlaceEleccionEscuela.Find(id);
            if (enlaceEleccionEscuela == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionEscuela);
        }

        // GET: /EnlaceEleccionesEscuelas/Create
        public ActionResult Create()
        {
            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre");
            ViewBag.EscuelaID = new SelectList(db.Escuela, "ID", "Nombre");
            return View();
        }

        // POST: /EnlaceEleccionesEscuelas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,EleccionID,EscuelaID")] EnlaceEleccionEscuela enlaceEleccionEscuela)
        {
            if (ModelState.IsValid)
            {
                db.EnlaceEleccionEscuela.Add(enlaceEleccionEscuela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionEscuela.EleccionID);
            ViewBag.EscuelaID = new SelectList(db.Escuela, "ID", "Nombre", enlaceEleccionEscuela.EscuelaID);
            return View(enlaceEleccionEscuela);
        }

        // GET: /EnlaceEleccionesEscuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionEscuela enlaceEleccionEscuela = db.EnlaceEleccionEscuela.Find(id);
            if (enlaceEleccionEscuela == null)
            {
                return HttpNotFound();
            }
            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionEscuela.EleccionID);
            ViewBag.EscuelaID = new SelectList(db.Escuela, "ID", "Nombre", enlaceEleccionEscuela.EscuelaID);
            return View(enlaceEleccionEscuela);
        }

        // POST: /EnlaceEleccionesEscuelas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,EleccionID,EscuelaID")] EnlaceEleccionEscuela enlaceEleccionEscuela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enlaceEleccionEscuela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionEscuela.EleccionID);
            ViewBag.EscuelaID = new SelectList(db.Escuela, "ID", "Nombre", enlaceEleccionEscuela.EscuelaID);
            return View(enlaceEleccionEscuela);
        }

        // GET: /EnlaceEleccionesEscuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionEscuela enlaceEleccionEscuela = db.EnlaceEleccionEscuela.Find(id);
            if (enlaceEleccionEscuela == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionEscuela);
        }

        // POST: /EnlaceEleccionesEscuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnlaceEleccionEscuela enlaceEleccionEscuela = db.EnlaceEleccionEscuela.Find(id);
            db.EnlaceEleccionEscuela.Remove(enlaceEleccionEscuela);
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
