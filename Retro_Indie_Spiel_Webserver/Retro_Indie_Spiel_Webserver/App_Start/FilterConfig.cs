using System.Web;
using System.Web.Mvc;

namespace Retro_Indie_Spiel_Webserver
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
