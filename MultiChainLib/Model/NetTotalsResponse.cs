using Newtonsoft.Json;

namespace MultiChainLib
{
    public class NetTotalsResponse
    {
        [JsonProperty("totalbytesrecv")]
        public long TotalsBytesRecv { get; set; }

        [JsonProperty("totalbytessent")]
        public long TotalsBytesSent { get; set; }

        [JsonProperty("timemillis")]
        public long TimeMillis { get; set; }
    }
}