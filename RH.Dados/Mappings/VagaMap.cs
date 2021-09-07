
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RH.Dados.Mappings
{
    public class VagaMap : EntityTypeConfiguration<Vaga>
    {
        public VagaMap()
        {

            ToTable("Vaga");

            HasKey(x => x.Id);
            Property(x => x.Descricao).IsRequired();

            HasMany(x => x.Candidatos).WithMany(x=>x.Vagas).Map(x=>x.ToTable("VagaCandidato"));
        }
    }
}