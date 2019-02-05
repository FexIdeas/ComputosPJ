using System.Net.Http.Formatting;
using System.Web.Http;

class WebApiConfig
{
    public static void Register(HttpConfiguration configuration)
    {
        configuration.Formatters.Clear();
        configuration.Formatters.Add(new JsonMediaTypeFormatter());
        configuration.Routes.MapHttpRoute("API Default", "api/webapi/{controller}/{id}",
            new { id = RouteParameter.Optional });
    }
}