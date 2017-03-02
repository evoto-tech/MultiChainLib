using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ListStreamKeyItemsResponse
    {
        [JsonProperty("publishers")]
        public List<string> Publishers { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("blocktime")]
        public int BlockTime { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }
    }
}