using RH.Dominio;
using RH.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RH.Api.Controllers
{
    public class VagaController : ApiController
    {
        private IVagaRepositorio _repository;

        public VagaController(IVagaRepositorio repository)
        {
            this._repository = repository;
        }

        #region Read
        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao recuperar as vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpGet]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public Task<HttpResponseMessage> GetById(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _repository.Get(id);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao recuperar as vagas");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        #endregion

        #region Create
        [HttpPost]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public Task<HttpResponseMessage> Post(Vaga vaga)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Create(vaga);
                response = Request.CreateResponse(HttpStatusCode.Created, vaga);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao inserir a vaga");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }


        #endregion

        #region Update
        [HttpPut]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public Task<HttpResponseMessage> Put(Vaga vaga)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Update(vaga);
                response = Request.CreateResponse(HttpStatusCode.OK, vaga);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao alterar a vaga");
                throw;
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region Delete
        [HttpDelete]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _repository.Delete(id);
                response = Request.CreateResponse(HttpStatusCode.OK, "Vaga removida com sucesso!");
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Falha ao excluir a tecnologia");
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
