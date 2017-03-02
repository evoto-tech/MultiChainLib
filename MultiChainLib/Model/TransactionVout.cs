using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class TransactionVout
    {
        public TransactionVout()
        {
            Assets = new List<object>();
            Permissions = new List<PermissionsResponse>();
        }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("n")]
        public int N { get; set; }

        [JsonProperty("scriptPubKey")]
        public ScriptPubKeyResponse ScriptPubKey { get; set; }

        [JsonProperty("assets")]
        public List<object> Assets { get; set; }

        [JsonProperty("permissions")]
        public List<PermissionsResponse> Permissions { get; set; }
    }
}