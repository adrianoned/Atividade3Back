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
    public class TecnologiaVagaRepositorio : ITecnologiaVagaRepositorio
    {
        private RHDataContext _db;

        public TecnologiaVagaRepositorio()
        {
            this._db = new RHDataContext();
        }

        public List<TecnologiaVaga> Get(int skip = 0, int take = 25)
        {
            return _db.TecnologiaVagas.ToList();
        }

        public TecnologiaVaga Get(int id)
        {
            return _db.TecnologiaVagas.First(x=>x.VagaId == id);
        }

        public void Create(TecnologiaVaga entity)
        {
            if(_db.TecnologiaVagas.Any(x=> x.TecnologiaId == entity.TecnologiaId && x.VagaId == entity.VagaId))
            {
                this.Update(entity);
            }
            else
            {
                _db.TecnologiaVagas.Add(entity);
                _db.SaveChanges();
            }
           
        }

        public void Update(TecnologiaVaga entity)
        {
            _db.Entry<TecnologiaVaga>(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.TecnologiaVagas.Remove(_db.TecnologiaVagas.Find(id));
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
