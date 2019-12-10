using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Club_de_Socios.Models;

namespace Club_de_Socios.Controllers
{
    public class AfiliadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Afiliadoes
        public ActionResult Index()
        {
            var afiliados = db.Afiliados.Include(a => a.Socio);
            return View(afiliados.ToList());
        }

        // GET: Afiliadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // GET: Afiliadoes/Create
        public ActionResult Create()
        {
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre");
            return View();
        }

        // POST: Afiliadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AfiliadoID,Nombre,Apellidos,Direccion,Telefono,Sexo,Edad,SocioID")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Afiliados.Add(afiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // GET: Afiliadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // POST: Afiliadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AfiliadoID,Nombre,Apellidos,Direccion,Telefono,Sexo,Edad,SocioID")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SocioID = new SelectList(db.Socios, "SocioID", "Nombre", afiliado.SocioID);
            return View(afiliado);
        }

        // GET: Afiliadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliados.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afiliado afiliado = db.Afiliados.Find(id);
            db.Afiliados.Remove(afiliado);
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
