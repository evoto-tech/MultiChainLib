using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ScriptPubKeyResponse
    {
        public ScriptPubKeyResponse()
        {
            Addresses = new List<string>();
        }

        [JsonProperty("asm")]
        public string Asm { get; set; }

        [JsonProperty("reqSigs")]
        public int ReqSigs { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; }
    }
}