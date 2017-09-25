using System.Web;
using System.Web.Mvc;
using Common.Web.Core.Filter;

namespace WebMvc5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorityFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
