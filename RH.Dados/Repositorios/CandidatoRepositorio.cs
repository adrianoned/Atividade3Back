using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RH.Dados.DataContext;
using RH.Dominio;
using RH.Dominio.Contratos;

namespace RH.Dados.Repositorios
{
    public class CandidatoRepositorio : ICandidatoRepositorio
    {
        private RHDataContext _db;

        public CandidatoRepositorio()
        {
            this._db = new RHDataContext();
        }

        public List<Candidato> Get(int skip = 0, int take = 25)
        {
            return _db.Candidatos.OrderBy(x => x.Nome).Skip(skip).Take(take).ToList();
        }

        public Candidato Get(int id)
        {
            return _db.Candidatos.Find(id);
        }

        public void Create(Candidato entity)
        {
            _db.Candidatos.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Candidato entity)
        {
            _db.Entry<Candidato>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Candidatos.Remove(_db.Candidatos.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
