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
    public class EnlaceEleccionTipoCategoriasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /EnlaceEleccionTipoCategorias/
        public ActionResult Index()
        {
            var enlaceelecciontipocategoria = db.EnlaceEleccionTipoCategoria.Include(e => e.Eleccion).Include(e => e.TipoCategoria);
            return View(enlaceelecciontipocategoria.ToList());
        }

        // GET: /EnlaceEleccionTipoCategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria = db.EnlaceEleccionTipoCategoria.Find(id);
            if (enlaceEleccionTipoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionTipoCategoria);
        }

        // GET: /EnlaceEleccionTipoCategorias/Create
        public ActionResult Create()
        {
            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre");
            ViewBag.TipoCategoriaID = new SelectList(db.TipoCategoria, "ID", "Nombre");
            return View();
        }

        // POST: /EnlaceEleccionTipoCategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,EleccionID,TipoCategoriaID")] EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria)
        {
            if (ModelState.IsValid)
            {
                if(db.EnlaceEleccionTipoCategoria.Where(e => e.EleccionID== enlaceEleccionTipoCategoria.EleccionID && e.TipoCategoriaID == enlaceEleccionTipoCategoria.TipoCategoriaID).Count() == 0)
                {
                    db.EnlaceEleccionTipoCategoria.Add(enlaceEleccionTipoCategoria);
                    db.SaveChanges();
                }                
                return RedirectToAction("Index");
            }

            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionTipoCategoria.EleccionID);
            ViewBag.TipoCategoriaID = new SelectList(db.TipoCategoria, "ID", "Nombre", enlaceEleccionTipoCategoria.TipoCategoriaID);
            return View(enlaceEleccionTipoCategoria);
        }

        // GET: /EnlaceEleccionTipoCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria = db.EnlaceEleccionTipoCategoria.Find(id);
            if (enlaceEleccionTipoCategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.selectEleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionTipoCategoria.EleccionID);
            ViewBag.selectTipoCategoriaID = new SelectList(db.TipoCategoria, "ID", "Nombre", enlaceEleccionTipoCategoria.TipoCategoriaID);
            return View(enlaceEleccionTipoCategoria);
        }

        // POST: /EnlaceEleccionTipoCategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,EleccionID,TipoCategoriaID")] EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria)
        {
            if (ModelState.IsValid)
            {
                if (db.EnlaceEleccionTipoCategoria.Where(e => e.EleccionID == enlaceEleccionTipoCategoria.EleccionID && e.TipoCategoriaID == enlaceEleccionTipoCategoria.TipoCategoriaID).Count() == 0)
                {
                    db.Entry(enlaceEleccionTipoCategoria).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            ViewBag.EleccionID = new SelectList(db.Eleccion, "ID", "Nombre", enlaceEleccionTipoCategoria.EleccionID);
            ViewBag.TipoCategoriaID = new SelectList(db.TipoCategoria, "ID", "Nombre", enlaceEleccionTipoCategoria.TipoCategoriaID);
            return View(enlaceEleccionTipoCategoria);
        }

        // GET: /EnlaceEleccionTipoCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria = db.EnlaceEleccionTipoCategoria.Find(id);
            if (enlaceEleccionTipoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionTipoCategoria);
        }

        // POST: /EnlaceEleccionTipoCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnlaceEleccionTipoCategoria enlaceEleccionTipoCategoria = db.EnlaceEleccionTipoCategoria.Find(id);
            db.EnlaceEleccionTipoCategoria.Remove(enlaceEleccionTipoCategoria);
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
