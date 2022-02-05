using Newtonsoft.Json;

namespace TradeArt.Lib.Models.GraphQL
{
    public class Market
    {
        [JsonProperty("marketSymbol")]
        public string MarketSymbol { get; set; }

        [JsonProperty("ticker")]
        public Ticker Ticker { get; set; }
    }
}
