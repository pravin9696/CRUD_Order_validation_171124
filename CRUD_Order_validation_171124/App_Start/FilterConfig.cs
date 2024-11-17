using System.Web;
using System.Web.Mvc;

namespace CRUD_Order_validation_171124
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
