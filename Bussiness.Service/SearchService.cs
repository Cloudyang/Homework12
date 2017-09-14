using Entity.Model;
using Bussiness.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Service
{
    public class SearchService : ISearch
    {

        public PageResult<CommodityModel> QueryCommodityPage(int pageIndex, int pageSize, string keyword, int[] categoryIdList, string priceFilter, string priceOrderBy)
        {
            RemoteSearchService.SearcherClient client = null;

            try
            {
                client = new RemoteSearchService.SearcherClient();
                string result = client.QueryCommodityPage(pageIndex, pageSize, keyword, categoryIdList, priceFilter, priceOrderBy);

                client.Close();//会关闭链接，但是如果网络异常了，会抛出异常而且关闭不了
                return Newtonsoft.Json.JsonConvert.DeserializeObject<PageResult<CommodityModel>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (client != null)
                    client.Abort();
                throw ex;
            }

        }
    }
}
