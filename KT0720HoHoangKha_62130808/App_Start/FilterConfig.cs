using System.Web;
using System.Web.Mvc;

namespace KT0720HoHoangKha_62130808
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
