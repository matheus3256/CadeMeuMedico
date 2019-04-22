using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logon.Models;

namespace Logon.Controllers
{
    public class CidadesController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        [Authorize]
        public ActionResult Index()
        {
            var cidades = db.Cidades.Include(c => c.Estado);
            return View(cidades.ToList());
        }

        [Authorize]
        public ActionResult Adicionar()
        {
            ViewBag.EstadoID = new SelectList(db.Estado, "ID", "Estado");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar([Bind(Include = "ID,Cidade,EstadoID")] Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                if (db.Cidades.Count(u => u.Cidade == cidades.Cidade) > 0)
                {
                    ModelState.AddModelError("Especialidade", "Essa Especialidade ja existe");
                    return View(cidades);
                }
                db.Cidades.Add(cidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoID = new SelectList(db.Estado, "ID", "Estado", cidades.EstadoID);
            return View(cidades);
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            if (cidades == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoID = new SelectList(db.Estado, "ID", "Estado", cidades.EstadoID);
            return View(cidades);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ID,Cidade,EstadoID")] Cidades cidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoID = new SelectList(db.Estado, "ID", "Estado", cidades.EstadoID);
            return View(cidades);
        }

        [Authorize]
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            if (cidades == null)
            {
                return HttpNotFound();
            }
            return View(cidades);
        }

        [Authorize]
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int id)
        {
            Cidades cidades = db.Cidades.Find(id);
            db.Cidades.Remove(cidades);
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
