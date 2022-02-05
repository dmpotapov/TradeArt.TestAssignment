using Newtonsoft.Json;
using System.Collections.Generic;

namespace TradeArt.Lib.Models.GraphQL
{
    public class AssetsWithPricesQueryResult
    {
        [JsonProperty("assets")]
        public List<Asset> Assets { get; set; }
    }
}
