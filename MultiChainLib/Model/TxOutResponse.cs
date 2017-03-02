using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class TxOutResponse
    {
        public TxOutResponse()
        {
            Assets = new List<TxAssetResponse>();
            Permissions = new List<object>();
        }

        [JsonProperty("bestblock")]
        public string BestBlock { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("scriptPubKey")]
        public ScriptPubKeyResponse ScriptPubKey { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("coinbase")]
        public bool Coinbase { get; set; }

        [JsonProperty("assets")]
        public List<TxAssetResponse> Assets { get; set; }

        [JsonProperty("permissions")]
        public List<object> Permissions { get; set; }
    }
}