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
    public class EntrevistaRepositorio : IEntrevistaRepositorio
    {
        private RHDataContext _db;

        public EntrevistaRepositorio()
        {
            this._db = new RHDataContext();
        }

        public List<Entrevista> Get(int skip = 0, int take = 25)
        {
            List<Entrevista> lstEntrevista = new List<Entrevista>();

            lstEntrevista = _db.Entrevistas.OrderBy(x => x.observacoes).Skip(skip).Take(take).ToList();

            foreach (var entrevista in lstEntrevista)
            {
                entrevista.Vaga = _db.Vagas.Find(entrevista.VagaId);
                entrevista.Candidato = _db.Candidatos.Find(entrevista.CandidatoId);
                entrevista.Candidato.Tecnologias = _db.Tecnologias.Where(x => x.Candidatos.Any(y => y.Id == entrevista.CandidatoId)).ToList();
            }

            return lstEntrevista;
        }

        public Entrevista Get(int id)
        {
            Entrevista entrevista = new Entrevista();

            entrevista = _db.Entrevistas.Find(id);

            entrevista.Vaga = _db.Vagas.Find(entrevista.VagaId);
            entrevista.Candidato = _db.Candidatos.Find(entrevista.CandidatoId);
            entrevista.Candidato.Tecnologias = _db.Tecnologias.Where(x => x.Candidatos.Any(y => y.Id == entrevista.CandidatoId)).ToList();
            return entrevista;
        }

        public void Create(Entrevista entity)
        {
            List<Tecnologia> lstTecnologia = new List<Tecnologia>();

            foreach (var item in entity.Candidato.Tecnologias)
            {


                Tecnologia obj = new Tecnologia();
                if (_db.Tecnologias.Where(x => x.Candidatos.Any(y => y.Id == entity.CandidatoId)).Count() > 0)
                    continue;

                obj = _db.Tecnologias.Find(item.Id);

                lstTecnologia.Add(obj);
            }
            entity.Candidato = _db.Candidatos.Find(entity.CandidatoId);
            entity.Candidato.AddTecnologias(lstTecnologia);
            entity.Vaga = _db.Vagas.Find(entity.VagaId);


            _db.Entrevistas.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Entrevista entity)
        {

            if (_db.Candidatos.Where(e => e.Id == entity.CandidatoId).Include(e => e.Tecnologias).Count() > 0)
            {
                var candidato = _db.Candidatos.Where(e => e.Id == entity.CandidatoId).Include(e => e.Tecnologias).First();

                foreach (var objTecnologia in candidato.Tecnologias)
                {
                    objTecnologia.Candidatos = null;
                }

                _db.SaveChanges();
            }

            List<Tecnologia> lstTecnologia = new List<Tecnologia>();

            foreach (var item in entity.Candidato.Tecnologias)
            {
                Tecnologia obj = new Tecnologia();
                //if (_db.Tecnologias.Where(x => x.Candidatos.Any(y => y.Id == entity.CandidatoId)).Count() > 0)
                //    continue;

                obj = _db.Tecnologias.Find(item.Id);

                lstTecnologia.Add(obj);
            }

            entity.Candidato = _db.Candidatos.Find(entity.CandidatoId);
            entity.Candidato.AddTecnologias(lstTecnologia);
            entity.Vaga = _db.Vagas.Find(entity.VagaId);
            _db.Entry<Entrevista>(entity).State = EntityState.Modified;
            _db.SaveChanges();

        
    }

    public void Delete(int id)
    {
        _db.Entrevistas.Remove(_db.Entrevistas.Find(id));
        _db.SaveChanges();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}
}
