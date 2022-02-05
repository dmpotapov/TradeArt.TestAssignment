using System.Collections.Generic;
using System.Threading.Tasks;
using TradeArt.Lib.Models.GraphQL;

namespace TradeArt.Lib.GraphQL
{
    public interface IGraphQLService
    {
        Task<IEnumerable<Asset>> GetAssetsWithPricesAsync(int pageSize, int maxItems);
    }
}
