using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Dados.Mappings
{
    public class EntrevistaMap: EntityTypeConfiguration<Entrevista>
    {
        public EntrevistaMap()
        {
            ToTable("Entrevista");

            HasKey(x => x.Id);
            Property(x => x.observacoes);

            HasRequired(t => t.Candidato).WithMany().HasForeignKey(t => t.CandidatoId);
            HasRequired(t => t.Vaga).WithMany().HasForeignKey(t => t.VagaId);

        }
    }
}
