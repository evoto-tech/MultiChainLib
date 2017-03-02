using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class ScriptResponse
    {
        public ScriptResponse()
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

        [JsonProperty("p2sh")]
        public string P2Sh { get; set; }
    }
}