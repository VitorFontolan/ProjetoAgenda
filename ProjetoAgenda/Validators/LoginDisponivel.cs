using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Data.Persistence;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAgenda.Validators {
    // Classe de validação customizada, para tal, deverá
    // herdar -> ValidationAttribute
    public class LoginDisponivel : ValidationAttribute {
        // Implementar o método IsValid
        // Retornar true se a validação está ok...
        // Retornar false se ocorreu um erro de validação
        public override bool IsValid(object value) {
            // Value -> representa o valor do elemento que está sendo validado
            string Login = (string)value;
            // Acessar a base de dados...
            UsuarioData d = new UsuarioData();
            return ! d.HasLogin(Login);
        }
    }
}