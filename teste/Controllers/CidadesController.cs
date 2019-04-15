using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace teste.Controllers
{
    public class CidadesController : Controller
    {
        private TrabalhoEntities db = new TrabalhoEntities();
        public ActionResult Index()
        {
            return View(db.Cidades.ToList());
        }
        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Cidades cidades1)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(cidades1);
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
            Cidades cidades1 = db.Cidades.Find(id);
            if (cidades1 == null)
            {
                return HttpNotFound();
            }
            return View(cidades1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IDCidade,Cidade")]Cidades cidades1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidades1).State = EntityState.Modified;
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
            Cidades cidades1 = db.Cidades.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(cidades1);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Cidades cidades1 = db.Cidades.Find(id);
            db.Cidades.Remove(cidades1);
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