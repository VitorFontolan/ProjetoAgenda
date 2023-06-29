using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping; //Mapeamento
using Projeto.Data.Entities; //Classes de entidade


namespace Projeto.Data.Mapping {
    public class CategoriaMap : ClassMap<Categoria> {

        public CategoriaMap() {
            Table("Categoria"); // Nome da Tabela...

            // Chave Primaria
            Id(c => c.IdCategoria, "IdCategoria").GeneratedBy.Identity();

            // Demais Atributos 
            Map(c => c.Nome, "Nome").Length(50).Not.Nullable();

            // Relacionamentos 
            HasMany(c => c.Tarefas).KeyColumn("IdCategoria").Inverse();
        }

    }
}
