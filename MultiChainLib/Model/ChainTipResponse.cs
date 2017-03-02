using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ChainTipResponse
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("branchlen")]
        public int BranchLen { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}