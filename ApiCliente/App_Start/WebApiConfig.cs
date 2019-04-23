using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiCliente
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "TelefonesId",
				routeTemplate: "api/clientes/{idCliente}/telefones/{idTelefone}",
				defaults: new { controller = "Telefones" }
			);

			config.Routes.MapHttpRoute(
				name: "Telefones",
				routeTemplate: "api/clientes/{idCliente}/telefones",
				defaults: new { controller = "Telefones" }
			);

			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
