using Newtonsoft.Json;

namespace MultiChainLib
{
    public class CreateRawTransactionTxIn
    {
        [JsonProperty("txid")]
        public string TxId { get; set; }

        [JsonProperty("vout")]
        public int Vout { get; set; }
    }
}