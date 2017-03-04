using System.Collections.Generic;
using Newtonsoft.Json;

namespace MultiChainLib.Model
{
    public class TransactionDetailsResponse
    {
        public TransactionDetailsResponse()
        {
            MyAddresses = new List<string>();
            Addresses = new List<string>();
            Permissions = new List<string>();
            Items = new List<string>();
            Data = new List<string>();
        }

        [JsonProperty("balance")]
        public TransactionBalanceResponse Balance { get; set; }

        [JsonProperty("myaddresses")]
        public List<string> MyAddresses { get; set; }

        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }

        [JsonProperty("items")]
        public List<string> Items { get; set; }

        [JsonProperty("data")]
        public List<string> Data { get; set; }

        [JsonProperty("confirmations")]
        public int Confirmations { get; set; }

        [JsonProperty("blockhash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockindex")]
        public int BlockIndex { get; set; }

        [JsonProperty("blocktime")]
        public long BlockTime { get; set; }

        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("timereceived")]
        public long TimeReceived { get; set; }
    }
}