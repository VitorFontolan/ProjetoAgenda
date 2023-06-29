using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; // Mapeamento
using Projeto.Data.Entities; // Classes de entidade

namespace Projeto.Data.Mapping {
    public class TarefaMap : ClassMap<Tarefa> {
        public TarefaMap() {
            Table("Tarefa"); // Nome da Tabela

            // Chave primaria
            Id(t => t.IdTarefa, "IdTarefa").GeneratedBy.Identity();

            // Demais propriedades
            Map(t => t.Titulo, "Titulo").Length(50).Not.Nullable();
            Map(t => t.Descricao, "Descricao").Not.Nullable();
            Map(t => t.DataHoraInicio, "DataHoraInicio").Not.Nullable();
            Map(t => t.DataHoraFim, "DataHoraFim").Not.Nullable();

            // Chaves estrangeiras
            References(f => f.Categoria).Column("IdCategoria"); // Foreign Key
            References(f => f.Usuario).Column("IdUsuario"); // Foreign Key
        }

    }
}
