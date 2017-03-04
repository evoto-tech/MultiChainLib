using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class TransactionBalanceResponse
    {
        public TransactionBalanceResponse()
        {
            Assets = new List<AssetBalanceResponse>();
        }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("assets")]
        public List<AssetBalanceResponse> Assets { get; set; }
    }
}