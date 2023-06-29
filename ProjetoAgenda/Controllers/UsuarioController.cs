using ProjetoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Util;
using System.Web.Security; // Autenticação.

namespace ProjetoAgenda.Controllers {

    [AllowAnonymous]
    public class UsuarioController : Controller {

        // GET: Usuario/Cadastro
        public ActionResult Cadastro() {
            return View(); // Page_load
        }

        // GET: Usuario/Login
        public ActionResult Login() {
            return View(); // Page_load
        }

        // POST: /Usuario/AutenticarUsuario
        [HttpPost]
        public ActionResult AutenticarUsuario(UsuarioModelLogin model) {

            // Verificar se não ocorreram erros de validação na model
            if (ModelState.IsValid) {
                try {
                    UsuarioData d = new UsuarioData(); // Persistencia...
                    Usuario u = d.Authenticate(model.Login,
                        Criptografia.GetMD5Hash(model.Senha));

                    if (u != null) { // Usuario foi encontrado...

                        // Gerar um Ticket de Acesso para o usuario...
                        FormsAuthentication.SetAuthCookie(u.Login, false);

                        // Armazenar o objeto Usuario em sessão...
                        Session.Add("usuariologado", u);

                        // Redirecionar para a Agenda...
                        return RedirectToAction("Index", "Agenda");
                    }
                    else { // Usuario não encontrado...
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch (Exception e) {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Login"); // Page_load
        }

        // POST: /Usuario/CadastrarUsuario
        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioModelCadastro model) {
            if (ModelState.IsValid) {
                try {
                    Usuario u = new Usuario() { // Entidade
                        Nome = model.Nome,
                        Login = model.Login,
                        Senha = Criptografia.GetMD5Hash(model.Senha),
                        DataCadastro = DateTime.Now
                    };

                    UsuarioData d = new UsuarioData(); // Persistencia
                    d.Insert(u); // Gravando na base de dados...

                    ViewBag.Mensagem = "Usuario " + u.Nome + ", cadastrado com sucesso.";
                    ModelState.Clear(); // Limpar o conteúdo do formulário
                }
                catch (Exception e) {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro"); // Page_load
        }

        [Authorize]
        public ActionResult Logout () {
            // Passo 1) Remover o ticket de acesso criado.
            FormsAuthentication.SignOut();

            // Passo 2) Remover o usuário logado da sessão.
            Session.Remove("usuariologado");
            Session.Abandon(); // Invalida a sessão.

            return View("Login");
        }
    }
}