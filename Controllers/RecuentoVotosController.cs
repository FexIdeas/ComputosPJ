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
    public class RecuentoVotosController : Controller
    {
        private ComputosPJEntities db = new ComputosPJEntities();

        // GET: /RecuentoVotos/
        public ActionResult Index()
        {
            var recuentovoto = db.RecuentoVoto.Include(r => r.AspNetUsers).Include(r => r.AspNetUsers1).Include(r => r.EnlaceEleccionTipoCategoriaLista).Include(r => r.Mesa);
            return View(recuentovoto.ToList());
        }

        // GET: /RecuentoVotos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecuentoVoto recuentoVoto = db.RecuentoVoto.Find(id);
            if (recuentoVoto == null)
            {
                return HttpNotFound();
            }
            return View(recuentoVoto);
        }

        // GET: /RecuentoVotos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioActualizacionID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.UsuarioCreacionID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.EnlaceEleccionTipoCategoriaListaID = new SelectList(db.EnlaceEleccionTipoCategoriaLista, "ID", "ID");
            ViewBag.MesaID = new SelectList(db.Mesa, "ID", "ID");
            return View();
        }

        // POST: /RecuentoVotos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CantidadVotos,EnlaceEleccionTipoCategoriaListaID,FechaCreacion,FechaActualizacion,UsuarioCreacionID,UsuarioActualizacionID,MesaID")] RecuentoVoto recuentoVoto)
        {
            if (ModelState.IsValid)
            {
                db.RecuentoVoto.Add(recuentoVoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioActualizacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioActualizacionID);
            ViewBag.UsuarioCreacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioCreacionID);
            ViewBag.EnlaceEleccionTipoCategoriaListaID = new SelectList(db.EnlaceEleccionTipoCategoriaLista, "ID", "ID", recuentoVoto.EnlaceEleccionTipoCategoriaListaID);
            ViewBag.MesaID = new SelectList(db.Mesa, "ID", "ID", recuentoVoto.MesaID);
            return View(recuentoVoto);
        }

        // GET: /RecuentoVotos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecuentoVoto recuentoVoto = db.RecuentoVoto.Find(id);
            if (recuentoVoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioActualizacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioActualizacionID);
            ViewBag.UsuarioCreacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioCreacionID);
            ViewBag.EnlaceEleccionTipoCategoriaListaID = new SelectList(db.EnlaceEleccionTipoCategoriaLista, "ID", "ID", recuentoVoto.EnlaceEleccionTipoCategoriaListaID);
            ViewBag.MesaID = new SelectList(db.Mesa, "ID", "ID", recuentoVoto.MesaID);
            return View(recuentoVoto);
        }

        // POST: /RecuentoVotos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CantidadVotos,EnlaceEleccionTipoCategoriaListaID,FechaCreacion,FechaActualizacion,UsuarioCreacionID,UsuarioActualizacionID,MesaID")] RecuentoVoto recuentoVoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recuentoVoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioActualizacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioActualizacionID);
            ViewBag.UsuarioCreacionID = new SelectList(db.AspNetUsers, "Id", "Email", recuentoVoto.UsuarioCreacionID);
            ViewBag.EnlaceEleccionTipoCategoriaListaID = new SelectList(db.EnlaceEleccionTipoCategoriaLista, "ID", "ID", recuentoVoto.EnlaceEleccionTipoCategoriaListaID);
            ViewBag.MesaID = new SelectList(db.Mesa, "ID", "ID", recuentoVoto.MesaID);
            return View(recuentoVoto);
        }

        // GET: /RecuentoVotos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecuentoVoto recuentoVoto = db.RecuentoVoto.Find(id);
            if (recuentoVoto == null)
            {
                return HttpNotFound();
            }
            return View(recuentoVoto);
        }

        // POST: /RecuentoVotos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecuentoVoto recuentoVoto = db.RecuentoVoto.Find(id);
            db.RecuentoVoto.Remove(recuentoVoto);
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
