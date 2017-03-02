using Newtonsoft.Json;

namespace MultiChainLib
{
    public class AssetBalanceResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("assetref")]
        public string AssetRef { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }
    }
}