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
    public class MedicosController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Cidade).Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        [Authorize]
        public ActionResult Adicionar()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "ID", "Cidade");
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Especialidade");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar([Bind(Include = "ID,Nome,CRM,Endereco,Bairro,Email,WebSiteBlog,EspecialidadeID,CidadeID")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CidadeID = new SelectList(db.Cidades, "ID", "Cidade", medicos.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Especialidade", medicos.EspecialidadeID);
            return View(medicos);
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "ID", "Cidade", medicos.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Especialidade", medicos.EspecialidadeID);
            return View(medicos);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "ID,Nome,CRM,Endereco,Bairro,Email,WebSiteBlog,EspecialidadeID,CidadeID")] Medicos medicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "ID", "Cidade", medicos.CidadeID);
            ViewBag.EspecialidadeID = new SelectList(db.Especialidades, "ID", "Especialidade", medicos.EspecialidadeID);
            return View(medicos);
        }

        [Authorize]
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medicos = db.Medicos.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

         [Authorize]
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmar(int id)
        {
            Medicos medicos = db.Medicos.Find(id);
            db.Medicos.Remove(medicos);
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
