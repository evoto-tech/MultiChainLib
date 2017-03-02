using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ScriptSigResponse
    {
        [JsonProperty("asm")]
        public string Asm { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }
    }
}