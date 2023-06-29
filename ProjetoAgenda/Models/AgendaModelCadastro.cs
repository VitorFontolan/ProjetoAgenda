using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations; // Mapeamento.
using Projeto.Data.Entities;
using Projeto.Data.Persistence;
using Projeto.Data.Dto;

namespace ProjetoAgenda.Models {
    public class AgendaModelCadastro {
        
        [Required(ErrorMessage = "Por favor, informe o título da tarefa.")]
        [Display(Name = "Título da Tarefa:")] // Label
        public string Titulo { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe a descrição da tarefa.")]
        [Display(Name = "Descrição:")] // Label
        public string Descricao { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe a data/hora de início da tarefa.")]
        [Display(Name = "Data/Hora de Início:")] // Label
        public DateTime DataHoraInicio { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe a data/hora de término da tarefa.")]
        [Display(Name = "Data/Hora de Término:")] // Label
        public DateTime DataHoraFim { get; set; } // Campo

        #region Campo de Seleção de Categorias

        [Required(ErrorMessage = "Por favor, selecione a categoria da tarefa.")]
        [Display(Name = "Selecione a Categoria:")] // Label
        public int IdCategoria { get; set; } // Capturar o valor selecionado

        public List<SelectListItem> ListagemCategorias {
            get {
                // Retornar uma lista com as categorias do banco de dados.
                List<SelectListItem> lista = new List<SelectListItem>();

                CategoriaData d = new CategoriaData();
                foreach(Categoria c in d.FindAll()) {
                    SelectListItem item = new SelectListItem();
                    item.Value = c.IdCategoria.ToString(); // Valor do campo
                    item.Text = c.Nome; // Texto exibido no campo
                    lista.Add(item); // Adicionar o item na lista
                }
                return lista; // Retornar a lista
            }
        }
        #endregion
    } 
    public class AgendaModelConsulta {
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        [Display(Name = "Data de Início:")]
        public DateTime DataIni { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de término.")]
        [Display(Name = "Data de Término:")]
        public DateTime DataFim { get; set; }

        // Propriedade para exibir o resultado da pesquisa.
        public List<TarefaDto> ListagemTarefas { get; set; } // Saída.
    }
}