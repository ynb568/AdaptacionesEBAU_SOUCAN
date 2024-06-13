using CapaPresentacion.Filters;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CheckSessionFilter());
        }
    }
}
