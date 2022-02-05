using Newtonsoft.Json;

namespace TradeArt.Lib.Models.GraphQL
{
    public class Ticker
    {
        [JsonProperty("lastPrice")]
        public string LastPrice { get; set; }
    }
}
