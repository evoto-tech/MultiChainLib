using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class ScriptSigResponse
    {
        [JsonProperty("asm")]
        public string Asm { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }
    }
}