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
    public class TipoCategoriasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /TipoCategorias/
        public ActionResult Index()
        {
            return View(db.TipoCategoria.ToList());
        }

        // GET: /TipoCategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCategoria tipoCategoria = db.TipoCategoria.Find(id);
            if (tipoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCategoria);
        }

        // GET: /TipoCategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoCategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre")] TipoCategoria tipoCategoria)
        {
            if (ModelState.IsValid)
            {
                db.TipoCategoria.Add(tipoCategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCategoria);
        }

        // GET: /TipoCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCategoria tipoCategoria = db.TipoCategoria.Find(id);
            if (tipoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCategoria);
        }

        // POST: /TipoCategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre")] TipoCategoria tipoCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCategoria);
        }

        // GET: /TipoCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCategoria tipoCategoria = db.TipoCategoria.Find(id);
            if (tipoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(tipoCategoria);
        }

        // POST: /TipoCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCategoria tipoCategoria = db.TipoCategoria.Find(id);
            db.TipoCategoria.Remove(tipoCategoria);
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
