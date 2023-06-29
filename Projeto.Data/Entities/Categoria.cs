using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Entities {
    public class Categoria {
        public virtual int IdCategoria { get; set; }
        public virtual string Nome { get; set; }

        // Relacionamento -> TER Muitos
        public virtual ICollection<Tarefa> Tarefas { get; set; }
    }
}
