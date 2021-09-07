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
    public class TecnologiaRepositorio : ITecnologiaRepositorio
    {
        private RHDataContext _db;

        public TecnologiaRepositorio()
        {
            this._db = new RHDataContext();
        }

        public List<Tecnologia> Get(int skip = 0, int take = 25)
        {
            return _db.Tecnologias.OrderBy(x => x.Descricao).Skip(skip).Take(take).ToList();
        }

        public Tecnologia Get(int id)
        {
            return _db.Tecnologias.Find(id);
        }

        public void Create(Tecnologia entity)
        {
            _db.Tecnologias.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Tecnologia entity)
        {
            _db.Entry<Tecnologia>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Tecnologias.Remove(_db.Tecnologias.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
