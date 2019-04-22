using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using teste.DAO;
using teste.Models;

namespace teste.Controllers
{
    public class MedicosController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        public ActionResult Index()
        {
            var medico1 = db.Medicos.Include(m => m.Cidade)
                .Include(m => m.Especialidade).ToList();
            return View(medico1);
        }
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade");
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidades" , "Especialidade");
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Medicos medico1)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico1);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico1.IDCidade);
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidades" , "Especialidade", medico1.IDEspecialidade);
            return View();

        }
        public ActionResult Editar (long? id)
        {
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico1 = db.Medicos.Find(id);
            if (medico1 ==null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Cidade", medico1.IDCidade);
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidades", "Especialidade", medico1.IDEspecialidade);
            return View(medico1); // retorna os dados no edit
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IDMedico,IDEspecialidades,CRM, Nome, Endereco, Bairro, IDCidade, Email, AtendePorConvenio, TemClinica, WebsiteBlog")]Medicos medico1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidades = new SelectList(db.Cidades, "IDCidade", "Cidade", medico1.IDCidade);
            ViewBag.IDEspecialidades = new SelectList(db.Especialidades, "IDEspecialidades", "Especialidade", medico1.IDEspecialidade);
            return View();

        }
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico1 = db.Medicos.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(medico1);
            
         }
        [HttpPost,ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Medicos medico1 = db.Medicos.Find(id);
            db.Medicos.Remove(medico1);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}