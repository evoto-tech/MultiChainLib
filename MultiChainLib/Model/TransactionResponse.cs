using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class TransactionResponse
    {
        public TransactionResponse()
        {
            WalletConflicts = new List<object>();
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("vout")]
        public int Vout { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockindex")]
        public int BlockIndex { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("walletconflicts")]
        public List<object> WalletConflicts { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long TimeReceived { get; set; }
    }
}