using RH.Dados.Repositorios;
using RH.Dominio;
using RH.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RH.Api.Controllers
{
    public class TecnologiaVagaController : ApiController
    {
        private ITecnologiaVagaRepositorio _repository;

        public TecnologiaVagaController(ITecnologiaVagaRepositorio repository)
        {
            this._repository = repository;
        }

        #region Read
        [HttpGet]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _repository.Get();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao recuperar as tecnologiaVagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        public Task<HttpResponseMessage> GetById(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _repository.Get(id);
                VagaCandidatoPontuacaoRepositorio obj = new VagaCandidatoPontuacaoRepositorio();
                response = Request.CreateResponse(HttpStatusCode.OK, obj.getRankingCandidatoVaga(result.VagaId));
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao recuperar as tecnologiaVagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        #endregion

        #region Create
        [HttpPost]
        public Task<HttpResponseMessage> Post(TecnologiaVaga tecnologiaVaga)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Create(tecnologiaVaga);
                VagaCandidatoPontuacaoRepositorio obj = new VagaCandidatoPontuacaoRepositorio();
                response = Request.CreateResponse(HttpStatusCode.Created, obj.getRankingCandidatoVaga(tecnologiaVaga.VagaId));
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao inserir a tecnologia Vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("api/VagasPontuacao")]
        public Task<HttpResponseMessage> Post(Vaga vaga)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                foreach (var item in vaga.TecnologiasVaga)
                {
                    _repository.Create(item);
                }
                VagaCandidatoPontuacaoRepositorio obj = new VagaCandidatoPontuacaoRepositorio();
                response = Request.CreateResponse(HttpStatusCode.Created, obj.getRankingCandidatoVaga(vaga.Id));
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao inserir a tecnologia Vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        #endregion

        #region Update
        [HttpPut]
        public Task<HttpResponseMessage> Put(TecnologiaVaga tecnologiaVaga)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Update(tecnologiaVaga);
                response = Request.CreateResponse(HttpStatusCode.OK, tecnologiaVaga);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao alterar a tecnologia Vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region Delete
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Delete(id);
                response = Request.CreateResponse(HttpStatusCode.OK, "Tecnologia Vagas removida com sucesso!");
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao excluir a tecnologia Vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}
