using System.Web;
using System.Web.Mvc;

namespace Proyecto_DSWI_SuperLoro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
