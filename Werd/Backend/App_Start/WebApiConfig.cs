using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Backend
{
    /// <summary>
    /// Configure the Web API application.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Register the configuration and change with custom settings.
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            var jsonSerializerSettings = jsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.Indented;
            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
