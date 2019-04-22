using teste.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Security.Claims;
using teste;
using teste.Utils;
using teste.DAO;

namespace teste.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();


        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }
         public ActionResult Cadastrar(CadastroUsuarioMetaDados viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
    }
            if (db.Usuarios.Count(u =>u.Login  == viewModel.Login)>0)
            {
                ModelState.AddModelError("Login", "Esse Login ja existe");
                return View(viewModel);
              }
            Usuarios novoUsuario = new Usuarios
            {
            Nome = viewModel.Nome,
            Login = viewModel.Login,
            Senha = Hash.GerarHash(viewModel.Senha)
             };
             db.Usuarios.Add(novoUsuario);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro realizado com sucesso";
            return View();
           
            
        }
        
       

    }
}