using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ReceivedResponse
    {
        public ReceivedResponse()
        {
            TxIds = new List<string>();
        }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("txids")]
        public List<string> TxIds { get; set; }
    }
}