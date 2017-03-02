using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class UnspentResponse
    {
        public UnspentResponse()
        {
            Assets = new List<UnspentAssetResponse>();
            Permissions = new List<PermissionsResponse>();
        }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("vout")]
        public int Vout { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("scriptPubKey")]
        public string ScriptPubKey { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("Confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("cansend")]
        public bool CanSend { get; set; }

        [JsonProperty("spendable")]
        public bool Spendable { get; set; }

        [JsonProperty("assets")]
        public List<UnspentAssetResponse> Assets { get; set; }

        [JsonProperty("permissions")]
        public List<PermissionsResponse> Permissions { get; set; }
    }
}