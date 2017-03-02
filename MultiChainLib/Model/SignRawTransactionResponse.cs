using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class SignRawTransactionResponse
    {
        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }
}