using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ListStreamResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createtxid")]
        public string CreateTxId { get; set; }

        [JsonProperty("streamref")]
        public string StreamRef { get; set; }

        [JsonProperty("open")]
        public bool Open { get; set; }

        [JsonProperty("details")]
        public object Details { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }

        [JsonProperty("synchronized")]
        public bool Synchronized { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("keys")]
        public int Keys { get; set; }

        [JsonProperty("publishers")]
        public int Publishers { get; set; }
    }
}