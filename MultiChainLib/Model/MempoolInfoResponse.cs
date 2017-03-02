using Newtonsoft.Json;

namespace MultiChainLib
{
    public class MempoolInfoResponse
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }
    }
}