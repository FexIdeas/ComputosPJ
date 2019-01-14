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
    public class TipoPartidosPoliticosController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /TipoPartidosPoliticos/
        public ActionResult Index()
        {
            return View(db.TipoPartidoPolitico.ToList());
        }

        // GET: /TipoPartidosPoliticos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPartidoPolitico tipoPartidoPolitico = db.TipoPartidoPolitico.Find(id);
            if (tipoPartidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(tipoPartidoPolitico);
        }

        // GET: /TipoPartidosPoliticos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoPartidosPoliticos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre")] TipoPartidoPolitico tipoPartidoPolitico)
        {
            if (ModelState.IsValid)
            {
                db.TipoPartidoPolitico.Add(tipoPartidoPolitico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPartidoPolitico);
        }

        // GET: /TipoPartidosPoliticos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPartidoPolitico tipoPartidoPolitico = db.TipoPartidoPolitico.Find(id);
            if (tipoPartidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(tipoPartidoPolitico);
        }

        // POST: /TipoPartidosPoliticos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre")] TipoPartidoPolitico tipoPartidoPolitico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPartidoPolitico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPartidoPolitico);
        }

        // GET: /TipoPartidosPoliticos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPartidoPolitico tipoPartidoPolitico = db.TipoPartidoPolitico.Find(id);
            if (tipoPartidoPolitico == null)
            {
                return HttpNotFound();
            }
            return View(tipoPartidoPolitico);
        }

        // POST: /TipoPartidosPoliticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPartidoPolitico tipoPartidoPolitico = db.TipoPartidoPolitico.Find(id);
            db.TipoPartidoPolitico.Remove(tipoPartidoPolitico);
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
