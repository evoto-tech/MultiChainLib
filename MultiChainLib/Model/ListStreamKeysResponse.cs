using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class ListStreamKeysResponse
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }
    }
}