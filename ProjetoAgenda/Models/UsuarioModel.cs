using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Mapeamento
using ProjetoAgenda.Validators;

namespace ProjetoAgenda.Models {
    public class UsuarioModelLogin {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        [Display(Name = "Informe seu Login:")] // Label
        public string Login { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        [Display(Name = "Informe sua senha:")] //Label
        public string Senha { get; set; } // Campo
    }

    public class UsuarioModelCadastro {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{4,50}$",
            ErrorMessage = "Erro. Nome inválido.")]
        [Display(Name = "Informe seu Nome:")] // Label
        public string Nome { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe o login do usuário.")]
        [RegularExpression("^[a-z0-9]{4,20}$",
            ErrorMessage = "Erro. Login inválido.")]
        [LoginDisponivel(ErrorMessage = "Erro. Este login encontra-se indisponível. Tente outro.")]
        [Display(Name = "Login de Acesso:")] // Label
        public string Login { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        [RegularExpression("^[A-Za-z0-9@]{4,20}$",
            ErrorMessage = "Erro. Senha inválida.")] // Label   
        public string Senha { get; set; } // Campo

        [Required(ErrorMessage = "Por favor, confirme a senha do usuário.")]
        [Compare("Senha",
            ErrorMessage = "Erro. Confirme sua senha corretamente.")]
        [Display(Name = "Confirme sua senha:")] // Label
        public string SenhaConfirm { get; set; } // Campo
    }
}