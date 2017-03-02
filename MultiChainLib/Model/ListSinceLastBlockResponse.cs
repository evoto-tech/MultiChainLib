using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib
{
    public class ListSinceLastBlockResponse
    {
        public ListSinceLastBlockResponse()
        {
            Transactions = new List<TransactionResponse>();
        }

        [JsonProperty("transactions")]
        public List<TransactionResponse> Transactions { get; set; }
    }
}