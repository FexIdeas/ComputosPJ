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
    public class EleccionesController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /Elecciones/
        public ActionResult Index()
        {
            var eleccion = db.Eleccion.Include(e => e.AspNetUsers);
            return View(eleccion.ToList());
        }

        // GET: /Elecciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleccion eleccion = db.Eleccion.Find(id);
            if (eleccion == null)
            {
                return HttpNotFound();
            }
            return View(eleccion);
        }

        // GET: /Elecciones/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: /Elecciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,Año,FechaCreacion,UsuarioID")] Eleccion eleccion)
        {
            if (ModelState.IsValid)
            {
                db.Eleccion.Add(eleccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", eleccion.UsuarioID);
            return View(eleccion);
        }

        // GET: /Elecciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleccion eleccion = db.Eleccion.Find(id);
            if (eleccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", eleccion.UsuarioID);
            return View(eleccion);
        }

        // POST: /Elecciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,Año,FechaCreacion,UsuarioID")] Eleccion eleccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.AspNetUsers, "Id", "Email", eleccion.UsuarioID);
            return View(eleccion);
        }

        // GET: /Elecciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleccion eleccion = db.Eleccion.Find(id);
            if (eleccion == null)
            {
                return HttpNotFound();
            }
            return View(eleccion);
        }

        // POST: /Elecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eleccion eleccion = db.Eleccion.Find(id);
            db.Eleccion.Remove(eleccion);
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
