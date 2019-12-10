using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Club_de_Socios.Models;

namespace Club_de_Socios.Controllers
{
    public class SociosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Socios
        public ActionResult Index()
        {
            return View(db.Socios.ToList());
        }

        // GET: Socios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SocioID,Nombre,Apellidos,Foto,Direccion,Telefono,Sexo,Edad,Fecha,Tipo_Membresia,Lugar_de_trabajo,Direccion_Oficina,Telefono_Oficina,Estado_de_Membresía,Fecha_Ingreso,Fecha_de_Salida")] Socio socio, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.FileName.EndsWith(".jpg"))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            upload.InputStream.CopyTo(memoryStream);
                            byte[] arreglo = memoryStream.GetBuffer();
                            socio.Foto = arreglo;
                            db.Socios.Add(socio);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Foto", "Es necesario que la imagen tenga formato JPG");
                    }

                }
                else
                {
                    ModelState.AddModelError("Foto", "Es necesario seleccionar una imagen");
                }

            }

            return View(socio);
        }

        // GET: Socios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SocioID,Nombre,Apellidos,Foto,Direccion,Telefono,Sexo,Edad,Fecha,Tipo_Membresia,Lugar_de_trabajo,Direccion_Oficina,Telefono_Oficina,Estado_de_Membresía,Fecha_Ingreso,Fecha_de_Salida")] Socio socio, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Socio _socio = new Socio();
                if (upload != null && upload.ContentLength > 0)
                {
                    if (upload.FileName.EndsWith(".jpg"))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            upload.InputStream.CopyTo(memoryStream);
                            byte[] arreglo = memoryStream.GetBuffer();
                            socio.Foto = arreglo;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Foto", "Es necesario que la imagen tenga formato JPG");
                        return View(socio);
                    }

                }
                else
                {
                    _socio = db.Socios.Find(socio.SocioID);
                    socio.Foto = _socio.Foto;
                }
                db.Entry(_socio).State = EntityState.Detached;
                db.Entry(socio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socios.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Socio socio = db.Socios.Find(id);
            db.Socios.Remove(socio);
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
        public ActionResult obtenerImagen(int id)
        {
            Socio socio = db.Socios.Find(id);
            byte[] byteImagen = socio.Foto;

            MemoryStream memoryStream = new MemoryStream(byteImagen);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "image/jpg");
        }

    }
}
