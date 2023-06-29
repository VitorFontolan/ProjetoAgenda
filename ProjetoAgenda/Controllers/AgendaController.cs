using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoAgenda.Models;
using Projeto.Data.Entities;
using Projeto.Data.Persistence;


namespace ProjetoAgenda.Controllers {

    [Authorize] // Requer autorizaçao de acesso /Agenda/...
    public class AgendaController : Controller {
        // GET: /Agenda/Index
        public ActionResult Index() {
            return View();
        }

        // GET: /Agenda/Cadastro
        public ActionResult Cadastro() {
            return View(new AgendaModelCadastro());
        }

        // GET: /Agenda/Consulta
        public ActionResult Consulta() {
            return View();
        }

        // POST: /Agenda/CadastrarTarefa
        [HttpPost]
        public ActionResult CadastrarTarefa(AgendaModelCadastro model) {
            if (ModelState.IsValid) { // Regras de validação estão ok?
                try {
                    Tarefa t = new Tarefa() { // Entidade
                        Titulo = model.Titulo,
                        Descricao = model.Descricao,
                        DataHoraInicio = model.DataHoraInicio,
                        DataHoraFim = model.DataHoraFim,
                        Categoria = new CategoriaData().Find(model.IdCategoria),
                        Usuario = (Usuario)Session["usuariologado"]
                    };

                    TarefaData d = new TarefaData(); // Persistência
                    d.Insert(t); // Gravando
                    ViewBag.Mensagem = "Tarefa " + t.Titulo + ", cadastrada com sucesso.";
                    ModelState.Clear(); // Limpando o conteúdo da model.
                }
                catch (Exception e) {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Cadastro", new AgendaModelCadastro()); // Nome da view.
        }

        [HttpPost]
        public ActionResult ConsultarTarefas(AgendaModelConsulta model) {
            if(ModelState.IsValid) {
                try {
                    TarefaData d = new TarefaData(); // Persistência.

                    Usuario u = (Usuario)Session["usuariologado"];
                    model.ListagemTarefas = d.FindAll(model.DataIni, model.DataFim, u.IdUsuario);
                }
                catch (Exception e) {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Consulta", model);
        }

        [HttpGet]
        public ActionResult ExcluirTarefa(int id) {
            try {
                TarefaData d = new TarefaData();
                Tarefa t = d.Find(id); // Buscando uma tarefa pelo ID.
                d.Delete(t); // Excluindo a tarefa.

                ViewBag.Mensagem = "Tarefa excluida com sucesso.";
            }
            catch(Exception e) {
                ViewBag.Mensagem = e.Message;
            }
            return View("Consulta");
        }
    }
}