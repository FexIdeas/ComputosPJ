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
    public class ListasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /Listas/
        public ActionResult Index()
        {
            var lista = db.Lista.Include(l => l.TipoPartidoPolitico);
            return View(lista.ToList());
        }

        // GET: /Listas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Lista.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: /Listas/Create
        public ActionResult Create()
        {
            ViewBag.TipoPartidoPoliticoID = new SelectList(db.TipoPartidoPolitico, "ID", "Nombre");
            return View();
        }

        // POST: /Listas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,TipoPartidoPoliticoID")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Lista.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoPartidoPoliticoID = new SelectList(db.TipoPartidoPolitico, "ID", "Nombre", lista.TipoPartidoPoliticoID);
            return View(lista);
        }

        // GET: /Listas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Lista.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoPartidoPoliticoID = new SelectList(db.TipoPartidoPolitico, "ID", "Nombre", lista.TipoPartidoPoliticoID);
            return View(lista);
        }

        // POST: /Listas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,TipoPartidoPoliticoID")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoPartidoPoliticoID = new SelectList(db.TipoPartidoPolitico, "ID", "Nombre", lista.TipoPartidoPoliticoID);
            return View(lista);
        }

        // GET: /Listas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Lista.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: /Listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista lista = db.Lista.Find(id);
            db.Lista.Remove(lista);
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
