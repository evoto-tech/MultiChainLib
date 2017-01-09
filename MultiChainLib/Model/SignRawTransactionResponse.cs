using Newtonsoft.Json;

namespace MultiChainLib
{
    public class SignRawTransactionResponse
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }
}