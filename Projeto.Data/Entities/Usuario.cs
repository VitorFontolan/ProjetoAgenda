using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Entities {

    /// <summary>
    /// Classe de Entidade
    /// </summary>

    public class Usuario {
        public virtual int IdUsuario { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual DateTime DataCadastro { get; set; }

        //Associação -> Muitos
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
