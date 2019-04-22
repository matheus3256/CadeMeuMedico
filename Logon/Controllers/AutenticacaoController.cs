using Logon.Models;
using Logon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logon.Utils;
using System.Security.Claims;

namespace Logon.Controllers
{
    public class AutenticacaoController : Controller
    {
        private UsuariosContext db = new UsuariosContext();

        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if(!ModelState.IsValid)
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
           
           
            return RedirectToAction("Login", "Autenticacao");
        }
        public ActionResult Login(String ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var usuario = db.Usuarios.FirstOrDefault(
                u => u.Login == viewModel.Login); //procura no banco pra procurar um usuario
            // verificar login
            if (usuario == null)
            {
                ModelState.AddModelError("Login", "O Usuario esta incorreto");
                return View(viewModel);
            }

            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "A Senha esta incorreta");
                return View(viewModel);
            }
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name ,usuario.Nome),
                new Claim("Login",usuario.Login)

            }, "AplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);
            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) ||
                Url.IsLocalUrl(viewModel.UrlRetorno))

                return Redirect(viewModel.UrlRetorno);

            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AplicationCookie");
            return RedirectToAction("Index", "Home");
        }


    }
}