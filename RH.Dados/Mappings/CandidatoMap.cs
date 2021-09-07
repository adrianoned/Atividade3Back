
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RH.Dados.Mappings
{
    public class CandidatoMap : EntityTypeConfiguration<Candidato>
    {
        public CandidatoMap()
        {
            ToTable("Candidato");

            HasKey(x => x.Id);
            Property(x => x.Nome).IsRequired();
            Property(x => x.DataNascimento).IsRequired();

        }
    }
}