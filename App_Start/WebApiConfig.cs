using System.Web.Http;

class WebApiConfig
{
    public static void Register(HttpConfiguration configuration)
    {
        configuration.Routes.MapHttpRoute("API Default", "api/webapi/{controller}/{id}",
            new { id = RouteParameter.Optional });
    }
}