using Newtonsoft.Json;

namespace MultiChainLib
{
    public class NetworkResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("limited")]
        public bool Limited { get; set; }

        [JsonProperty("reachable")]
        public bool Reachable { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }
    }
}