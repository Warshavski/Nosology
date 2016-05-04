using System.Web;
using System.Web.Mvc;

namespace Escyug.Nosology.Web.App
{
    public sealed class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
