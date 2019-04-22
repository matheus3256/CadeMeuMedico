using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using teste.DAO;
using teste.Models;

namespace teste.Controllers
{
    public class EspecialidadesController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        public ActionResult Index()
        {
            return View(db.Especialidades.ToList());
        }
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Especialidades especialidade1)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidade1);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidade1 = db.Especialidades.Find(id);
            if (especialidade1 == null)
            {
                return HttpNotFound();
            }
            return View(especialidade1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IDEspecialidades,Especialidade")]Especialidades especialidade1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidade1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidade1 = db.Especialidades.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(especialidade1);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Especialidades especialidade1 = db.Especialidades.Find(id);
            db.Especialidades.Remove(especialidade1);
            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateException)
            {
              //  string Message("Nao é possivel excluir uma especialidade " + e.Message);
            }

            

            return RedirectToAction("index");
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