
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RH.Dados.Mappings
{
    public class TecnologiaMap:EntityTypeConfiguration<Tecnologia>
    {
        public TecnologiaMap()
        {

            ToTable("Tecnologia");

            HasKey(x => x.Id);
            Property(x => x.Descricao).IsRequired();

            HasMany(x => x.Candidatos).WithMany(x => x.Tecnologias).Map(x => x.ToTable("TecnologiaCandidato"));
        }
    }
}