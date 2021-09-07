using RH.Dados.Mappings;
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Dados.DataContext
{
    public class RHDataContext : DbContext
    {
        public RHDataContext() : base("RHConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                List<string> lstErros = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    lstErros.Add($"Entidade do tipo {eve.Entry.Entity.GetType().Name.ToString()} no estado {eve.Entry.State.ToString()} tem os seguintes erros de validação: ");
                    //Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                     //   eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        lstErros.Add($"- Property: {ve.PropertyName}, Erro: {ve.ErrorMessage}");
                        //Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                        //    ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Entrevista> Entrevistas { get; set; }
        public DbSet<TecnologiaVaga> TecnologiaVagas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TecnologiaMap());
            modelBuilder.Configurations.Add(new VagaMap());
            modelBuilder.Configurations.Add(new CandidatoMap());
            modelBuilder.Configurations.Add(new TecnologiaVagaMap());
            modelBuilder.Configurations.Add(new EntrevistaMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
