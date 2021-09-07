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
    public class VagaRepositorio : IVagaRepositorio
    {
        private RHDataContext _db;

        public VagaRepositorio()
        {
            this._db = new RHDataContext();
        }

        public List<Vaga> Get(int skip = 0, int take = 25)
        {
            return _db.Vagas.OrderBy(x => x.Descricao).Skip(skip).Take(take).ToList();
        }

        public Vaga Get(int id)
        {
            return _db.Vagas.Find(id);
        }

        public void Create(Vaga entity)
        {
            _db.Vagas.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Vaga entity)
        {
            _db.Entry<Vaga>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Vagas.Remove(_db.Vagas.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
