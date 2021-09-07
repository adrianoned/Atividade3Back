using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RH.Dados.DataContext;
using RH.Dados.Repositorios;
using RH.Dominio.Contratos;
using RH.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace RH.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web


            // DI
            var container = new UnityContainer();
            container.RegisterType<RHDataContext, RHDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ITecnologiaRepositorio, TecnologiaRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IVagaRepositorio, VagaRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ICandidatoRepositorio, CandidatoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IEntrevistaRepositorio, EntrevistaRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ITecnologiaVagaRepositorio, TecnologiaVagaRepositorio>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            //Remove o XML
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);


            // Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            //// CORS
            config.EnableCors();

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
