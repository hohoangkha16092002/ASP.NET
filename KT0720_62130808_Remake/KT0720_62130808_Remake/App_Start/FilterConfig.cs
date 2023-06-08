using System.Web;
using System.Web.Mvc;

namespace KT0720_62130808_Remake
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
