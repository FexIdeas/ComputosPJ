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
    public class EnlaceEleccionTipoCategoriaListasController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /EnlaceEleccionTipoCategoriaListas/
        public ActionResult Index()
        {
            var enlaceelecciontipocategorialista = db.EnlaceEleccionTipoCategoriaLista.Include(e => e.EnlaceEleccionTipoCategoria).Include(e => e.Lista);
            return View(enlaceelecciontipocategorialista.ToList());
        }

        // GET: /EnlaceEleccionTipoCategoriaListas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista = db.EnlaceEleccionTipoCategoriaLista.Find(id);
            if (enlaceEleccionTipoCategoriaLista == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionTipoCategoriaLista);
        }

        // GET: /EnlaceEleccionTipoCategoriaListas/Create
        public ActionResult Create()
        {
            var dropdown_enlaceEleccionTipoCategoria =
               db.EnlaceEleccionTipoCategoria
               .Select(e => new
               {
                   ID = e.ID,
                   textValue = e.Eleccion.Nombre + " " + e.TipoCategoria.Nombre
               }
               ).ToList();

            ViewBag.EnlaceEleccionTipoCategoriaID = new SelectList(dropdown_enlaceEleccionTipoCategoria, "ID", "textValue");
           // ViewBag.EnlaceEleccionTipoCategoriaID = new SelectList(db.EnlaceEleccionTipoCategoria, "ID", "ID");
            ViewBag.ListaID = new SelectList(db.Lista, "ID", "Nombre");
            return View();
        }

        // POST: /EnlaceEleccionTipoCategoriaListas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ListaID,EnlaceEleccionTipoCategoriaID")] EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista)
        {
            if (ModelState.IsValid)
            {
                if (db.EnlaceEleccionTipoCategoriaLista.Where(e=> e.ListaID==enlaceEleccionTipoCategoriaLista.ListaID && e.EnlaceEleccionTipoCategoriaID == enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID).Count() == 0)
                {
                    db.EnlaceEleccionTipoCategoriaLista.Add(enlaceEleccionTipoCategoriaLista);
                    db.SaveChanges();
                }               
                return RedirectToAction("Index");
            }

            ViewBag.EnlaceEleccionTipoCategoriaID = new SelectList(db.EnlaceEleccionTipoCategoria, "ID", "ID", enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID);
            ViewBag.ListaID = new SelectList(db.Lista, "ID", "Nombre", enlaceEleccionTipoCategoriaLista.ListaID);
            return View(enlaceEleccionTipoCategoriaLista);
        }

        // GET: /EnlaceEleccionTipoCategoriaListas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista = db.EnlaceEleccionTipoCategoriaLista.Find(id);
            if (enlaceEleccionTipoCategoriaLista == null)
            {
                return HttpNotFound();
            }
            var dropdown_enlaceEleccionTipoCategoria =
              db.EnlaceEleccionTipoCategoria
              .Select(e => new
              {
                  ID = e.ID,
                  textValue = e.Eleccion.Nombre + " " + e.TipoCategoria.Nombre
              }
              ).ToList();

            ViewBag.selectEleccionCategoriaID = new SelectList(dropdown_enlaceEleccionTipoCategoria, "ID", "textValue",enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID);
            //ViewBag.EnlaceEleccionTipoCategoriaID = new SelectList(db.EnlaceEleccionTipoCategoria, "ID", "ID", enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID);
            ViewBag.selectListaID = new SelectList(db.Lista, "ID", "Nombre", enlaceEleccionTipoCategoriaLista.ListaID);
            return View(enlaceEleccionTipoCategoriaLista);
        }

        // POST: /EnlaceEleccionTipoCategoriaListas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ListaID,EnlaceEleccionTipoCategoriaID")] EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista)
        {
            if (ModelState.IsValid)
            {
                if (db.EnlaceEleccionTipoCategoriaLista.Where(e => e.ListaID == enlaceEleccionTipoCategoriaLista.ListaID && e.EnlaceEleccionTipoCategoriaID == enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID).Count() == 0)
                {
                    db.Entry(enlaceEleccionTipoCategoriaLista).State = EntityState.Modified;
                    db.SaveChanges();
                }               
                return RedirectToAction("Index");
            }
            ViewBag.EnlaceEleccionTipoCategoriaID = new SelectList(db.EnlaceEleccionTipoCategoria, "ID", "ID", enlaceEleccionTipoCategoriaLista.EnlaceEleccionTipoCategoriaID);
            ViewBag.ListaID = new SelectList(db.Lista, "ID", "Nombre", enlaceEleccionTipoCategoriaLista.ListaID);
            return View(enlaceEleccionTipoCategoriaLista);
        }

        // GET: /EnlaceEleccionTipoCategoriaListas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista = db.EnlaceEleccionTipoCategoriaLista.Find(id);
            if (enlaceEleccionTipoCategoriaLista == null)
            {
                return HttpNotFound();
            }
            return View(enlaceEleccionTipoCategoriaLista);
        }

        // POST: /EnlaceEleccionTipoCategoriaListas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnlaceEleccionTipoCategoriaLista enlaceEleccionTipoCategoriaLista = db.EnlaceEleccionTipoCategoriaLista.Find(id);
            db.EnlaceEleccionTipoCategoriaLista.Remove(enlaceEleccionTipoCategoriaLista);
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
