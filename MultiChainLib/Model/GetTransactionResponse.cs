using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class GetTransactionResponse
    {
        public GetTransactionResponse()
        {
            Details = new List<TransactionResponse>();
            WalletConflicts = new List<object>();
        }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("blocktime")]
        public long BlockTime { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long TimeReceived { get; set; }

        [JsonProperty("hex")]
        public string Hex { get; set; }

        [JsonProperty("walletconflicts")]
        public List<object> WalletConflicts { get; set; }

        [JsonProperty("details")]
        public List<TransactionResponse> Details { get; set; }
    }
}