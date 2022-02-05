using Newtonsoft.Json;
using System.Collections.Generic;

namespace TradeArt.Lib.Models.GraphQL
{
    public class Asset
    {
        [JsonProperty("assetName")]
        public string AssetName { get; set; }

        [JsonProperty("assetSymbol")]
        public string AssetSymbol { get; set; }

        [JsonProperty("marketCap")]
        public object MarketCap { get; set; }

        [JsonProperty("markets")]
        public List<Market> Markets { get; set; }
    }
}
