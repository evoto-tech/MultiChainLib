using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class MempoolInfoResponse
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }
    }
}