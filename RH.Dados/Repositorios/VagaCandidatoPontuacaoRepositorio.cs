using RH.Dados.DataContext;
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Dados.Repositorios
{
    public class VagaCandidatoPontuacaoRepositorio : IDisposable
    {
        private RHDataContext _db;
        public VagaCandidatoPontuacaoRepositorio()
        {
            this._db = new RHDataContext();
        }

        public VagaCandidatoPontuacao getRankingCandidatoVaga(int id)
        {
            VagaCandidatoPontuacao objVagaCandidatoPontuacao = new VagaCandidatoPontuacao();
            Vaga objVaga = _db.Vagas.Find(id);

            objVagaCandidatoPontuacao.Vaga = objVaga;

            List<TecnologiaVaga> lstTecnologiasVaga = new List<TecnologiaVaga>();
            lstTecnologiasVaga.AddRange( _db.TecnologiaVagas.Where(x => x.VagaId == id).ToList());

            List<Entrevista> lstEntrevistas = new List<Entrevista>();
            lstEntrevistas.AddRange(_db.Entrevistas.Where(x => x.VagaId == id).ToList());

            foreach (var objEntrevista in lstEntrevistas)
            {
                CandidatoPontuacao objCandidatoPontuacao = new CandidatoPontuacao();
                objCandidatoPontuacao.Candidato = _db.Candidatos.First(x=> x.Id == objEntrevista.CandidatoId);

                List<Tecnologia> lstTecnologias = new List<Tecnologia>();
                lstTecnologias.AddRange(_db.Tecnologias.Where(x=> x.Candidatos.Any(y=>y.Id == objCandidatoPontuacao.Candidato.Id)).ToList()) ;

                objCandidatoPontuacao.Pontuacao = lstTecnologiasVaga.Where(x => lstTecnologias.Any(y => y.Id == x.TecnologiaId)).Sum(x => x.Peso);

                objVagaCandidatoPontuacao.lstcandidatoPontucao.Add(objCandidatoPontuacao);
            }

            objVagaCandidatoPontuacao.lstcandidatoPontucao = objVagaCandidatoPontuacao.lstcandidatoPontucao.OrderByDescending(x=> x.Pontuacao).ToList();

            return objVagaCandidatoPontuacao;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
