
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace RH.Dados.Mappings
{
    public class TecnologiaVagaMap: EntityTypeConfiguration<TecnologiaVaga>
    {
        public TecnologiaVagaMap()
        {
            ToTable("TecnologiaVaga");

            HasKey(x => new { x.VagaId, x.TecnologiaId });
            Property(x => x.Peso).IsRequired();

        }
       
    }
}